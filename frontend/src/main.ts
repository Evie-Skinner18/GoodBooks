import Vue from 'vue'
import App from './App.vue'
import router from './router'
import moment from 'moment'

Vue.config.productionTip = false

// make the date more human friendly
Vue.filter('humanise', function(date: Date){
  return moment(date).format('Do MMMM YYYY');
});

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
