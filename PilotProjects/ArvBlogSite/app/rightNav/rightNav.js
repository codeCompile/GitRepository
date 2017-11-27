angular.module('myApp.rightNavView', ['ui.router'])


.service('rightNavService', function ($http) {
           var url = 'http://thinktank.azurewebsites.net/api/AutoSuggest/GetAutoSuggestionItems';
    return {
        get: function (inputStr) {
            return $http.get(url, { params: { "input": inputStr } }).then(function (resp) {
                return resp.data; 
            });
        }
    };
})
.controller('rightNavController', function ($scope,rightNavService) {
    //autoSuggestService.get('s').then(function (data) {
    //    $scope.items = data;
    //});

     $scope.recentPostItems = ["Aliquam tincidunt mauris",
		"Vestibulum auctor dapibus  lipsum",
		"Nunc dignissim risus consecu",
		"Cras ornare tristiqu"];

	 $scope.recentCommentItems = ["<a href=\"#\">Amada Doe </a> on <a href=\"#\">Hello World!</a>",
					 "<a href=\"#\">Peter Doe </a> on <a href=\"#\"> Photography</a>",
					 "<a href=\"#\">Steve Roberts  </a> on <a href=\"#\">HTML5/CSS3</a>"];

    $scope.recentArchieveList = ["October 2013",
"September 2013",
"August 2013",
"July 2013"];

$scope.recentCategogyList = ["Vivamus vestibulum nulla"];

});