import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
var platform = platformBrowserDynamic();
if (module.hot) {
    module.hot.accept();
    module.hot.dispose(function () {
        var oldRootElem = document.querySelector('app');
        var newRootElem = document.createElement('app');
        oldRootElem.parentNode.insertBefore(newRootElem, oldRootElem);
        platform.destroy();
    });
}
//# sourceMappingURL=main.js.map