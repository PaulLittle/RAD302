(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("productResource",
                ["$resource",
                 "appSettings",
                    productResource])

    function productResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/products/:id", null,
            {
                GetPids: {
                    url: appSettings.serverPath + "/api/products/GetPids/",
                    method: 'GET', isArray: true
                },
                update: { method: 'PUT', params: { id: '@id' } },
                query: { method: 'GET', params: { id: '' }, isArray: true },
                post: { method: 'POST' },
                update: { method: 'PUT', params: { id: '@id' } },
                remove: { method: 'DELETE' }
            })
    };
                
    
}());
