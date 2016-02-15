self.addEventListener("message", function (ev) {
    var fichero = ev.data; 
    var lector = new FileReaderSync();
    lector.onload = function () {
        self.postMessage(lector.result);
    }
    lector.readAsText(fichero);
}, false);