window.Blazor.defaultReconnectionHandler.onConnectionDown = function () {
    alert('hotReload');
    window.location.reload();
};