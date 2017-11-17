'use strict';

// Declare app level module which depends on views, and components
angular.module('myApp', [
  'ngRoute',
  'myApp.view1',
  'myApp.view2',
  'myApp.version'
]).
config(['$locationProvider', '$routeProvider', function($locationProvider, $routeProvider) {
  $locationProvider.hashPrefix('!');
 $routeProvider.when('/about', {
    templateUrl: 'about.html'
  })
   .when('/single', {
      templateUrl: 'single.html'
    })
     .when('/contact', {
      templateUrl: 'contact.html'
    });
  $routeProvider.otherwise({redirectTo: '/view1'});
}]);
