(() => {
    'use strict';

    const tbody = document.getElementById('servidor-mensagens');
    const status = document.getElementById('servidor-status');
    const aviso = document.getElementById('servidor-aviso');
    const formatInterval = new Intl.NumberFormat('pt-BR', { minimumFractionDigits: 3, maximumFractionDigits: 3 });
    let socket;
    let reconnectTimer;
    let stopped = false;
    let previousReceived = null;
    let invalidCount = 0;

    function setStatus(text, color) {
        status.textContent = text;
        status.className = `badge bg-${color}`;
    }

    function receive(event) {
        const receivedAt = new Date();
        const receivedTick = performance.now();
        let message;
        try {
            message = JSON.parse(event.data);
            if (!message || !Number.isInteger(message.idReceptora) ||
                !['codigoCliente', 'particao', 'evento'].every(key => typeof message[key] === 'string')) {
                throw new Error('Formato inválido');
            }
        } catch {
            invalidCount++;
            aviso.hidden = false;
            aviso.textContent = `${invalidCount} mensagem(ns) fora do formato esperado ignorada(s).`;
            return;
        }

        const interval = previousReceived === null ? '—' : formatInterval.format((receivedTick - previousReceived) / 1000);
        previousReceived = receivedTick;
        const timestamp = receivedAt.toLocaleString('pt-BR') + '.' + String(receivedAt.getMilliseconds()).padStart(3, '0');
        const row = document.createElement('tr');
        for (const value of [timestamp, interval, message.idReceptora, message.codigoCliente, message.particao, message.evento]) {
            const cell = document.createElement('td');
            cell.textContent = String(value);
            row.appendChild(cell);
        }
        document.getElementById('servidor-vazio')?.remove();
        tbody.prepend(row);
        if (tbody.children.length > 1000) tbody.lastElementChild.remove();
    }

    function scheduleReconnect() {
        if (stopped) return;
        setStatus('Desconectado. Reconectando em 5 segundos...', 'warning');
        clearTimeout(reconnectTimer);
        reconnectTimer = setTimeout(connect, 5000);
    }

    function connect() {
        if (stopped) return;
        setStatus('Conectando...', 'secondary');
        try {
            socket = new WebSocket('wss://nodered.gbm-monitor.com/ws/healthcheck');
            socket.onopen = () => {
                previousReceived = null;
                setStatus('Conectado — ouvindo mensagens', 'success');
            };
            socket.onmessage = receive;
            socket.onerror = () => setStatus('Falha na conexão com o servidor', 'danger');
            socket.onclose = scheduleReconnect;
        } catch {
            scheduleReconnect();
        }
    }

    window.addEventListener('pagehide', () => {
        stopped = true;
        clearTimeout(reconnectTimer);
        if (socket) {
            socket.onclose = null;
            socket.onmessage = null;
            socket.close();
        }
    });
    window.addEventListener('pageshow', event => {
        if (event.persisted) {
            stopped = false;
            connect();
        }
    });
    connect();
})();
