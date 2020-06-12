<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/goodbooksLogo.png">
    <HelloWorld msg="Welcome to GoodBooks!"/>
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'Home',
  components: {
    HelloWorld
  }
}
</script>
