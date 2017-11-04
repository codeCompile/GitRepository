angular.module('app').controller('autoSuggestController', function ($scope, autoSuggestService) {
    //autoSuggestService.get('s').then(function (data) {
    //    $scope.items = data;
    //});
    $scope.name = '';
    $scope.onItemSelected = function ()
    {
        console.log('selected=' + $scope.name);
    };
    $scope.onInputtext = function (input) 
    {
        if (input)
            autoSuggestService.get(input).then(function (data) {
                $scope.items = data;
            });
        else
            $scope.items = [];
    };

});

