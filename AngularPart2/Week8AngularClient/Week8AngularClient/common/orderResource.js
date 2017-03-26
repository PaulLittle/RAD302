(function () {
    "use strict";

    angular
    .module("common.services")
    .factory("orderResource",
    ["$resource",
        "appSettings",
        orderResource])

    function orderResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/orders/:id", null,
            {                
                GetCids: {
                    url: appSettings.serverPath + "/api/customers/GetCids/",
                    method: 'GET', isArray: true
                },
                GetOrders: {
                    url: appSettings.serverPath + "/api/orders/GetOrders/",
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

//Orders: $resource(appSettings.serverPath + "/api/orders/"),
//OrdersWithProducts: $resource(appSettings.serverPath + "/api/orders/getOrdersWithProducts/ID/:id"),
//Customers: $resource(appSettings.serverPath + "/api/customers/"),
//GetOids: {
//        url: appSettings.serverPath + "/api/customers/GetOids/",
//        method: 'GET', isArray: true
//},
