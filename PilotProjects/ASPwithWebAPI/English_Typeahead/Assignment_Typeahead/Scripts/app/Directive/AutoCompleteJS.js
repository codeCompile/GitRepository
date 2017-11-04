(function() {
    angular.module('angular-selectize', []);

    angular.module('angular-selectize').directive('selectize', function($timeout) {
        return {
            // Restrict it to be an attribute in this case
            restrict: 'A',
            require: '?ngModel',
            // responsible for registering DOM listeners as well as updating the DOM
            link: function(scope, element, attrs, ngModel) {
                var $element;
                $timeout(function() {
                    $element = $(element).selectize(scope.$eval(attrs.selectize));
                    if(!ngModel){
                        console.log('no ngModel')
                        return;
                    }
                    
                    $(element).selectize().on('change',function(){
                        scope.$apply(function(){
                            var newValue = $(element).selectize().val();
                            console.log('change:',newValue);                    
                            ngModel.$setViewValue(newValue);
                        });
                    });
                });
            }
        };
    });

}).call(this);
window.d = "hello";