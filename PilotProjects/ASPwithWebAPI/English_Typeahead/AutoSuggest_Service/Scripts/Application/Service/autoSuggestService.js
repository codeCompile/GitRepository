angular.module('app', [])
       .service('autoSuggestService', function ($http) {
           var url = 'api/AutoSuggest/GetAutoSuggestItem';
    return {
        get: function (inputStr) {
            return $http.get(url, { params: { "input": inputStr } }).then(function (resp) {
                return resp.data; 
            });
        }
    };
});