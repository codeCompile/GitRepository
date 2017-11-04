angular
     .module('app')
     .component('autoCompleteComponent', {
         template: '<h1>Hello {{$ctrl.name}}!</h1>',
         bindings: {
             name: "<"
         },
         controller: function () {
             // You can access the bindings here or inside your view
             console.log(this.name) // -> World
         }
     });