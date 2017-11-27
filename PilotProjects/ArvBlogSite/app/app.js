'use strict';

// Declare app level module which depends on views, and components
angular.module('myApp', [
  'ui.router',
  'ngRoute',
  'myApp.view1',
  'myApp.view2',
  'myApp.searchView',
  'myApp.version',
  'myApp.rightNavView'
])
.config(['$locationProvider', '$routeProvider', function($locationProvider, $routeProvider) {
  //$locationProvider.hashPrefix('!');
 $routeProvider.when('/about', {
    templateUrl: 'about.html'
  }).when('/main', {
      templateUrl: 'single.html'
    })
    .when('/contact', {
      templateUrl: 'contact.html'
    })
    .when('/main/view1', {
      templateUrl: 'view1/view1.html'
    })
     .when('/main/view2', {
      templateUrl: 'view2/view2.html'
    });
     
  //$routeProvider.otherwise({redirectTo: '/main'});
}])
.config(function($stateProvider, $urlRouterProvider){
    // For any unmatched url, send to /route1
    //$urlRouterProvider.otherwise("/main")
      
     $stateProvider
        .state('main', {
            url: "/main",
           //abstract:true ,
            views: {
               "searchView": {
                    templateUrl: 'rightNav/rightNav.html',
                    controller: 'rightNavController'
                },
                 "rightNavView": {
                    templateUrl: 'searchView/search.html',
                    controller: 'autoSuggestController'
                }
            }
        })
        .state('main.view1', {
            url: "/view1",
           //abstract:true ,
            views: {
           "mainView" :{
                    templateUrl: 'view1/view1.html'
                }
            }
        })
         .state('main.view2', {
            url: "/view2",
           //abstract:true ,
            views: {
                
                "mainView" :{
                    templateUrl: 'view2/view2.html'
                }
            }
        })  
    });
