<template>
  <div>
    <ul v-bind:key="item" v-for="item in list">
      {{ item }}
    </ul>
  </div>
</template>

<script>
export default {
  name: 'NumberList',
  props: {
    list: Array
  }
}
</script>

<style scoped>
div {
  border: 1.5px solid black;
  max-width: inherit;
  max-height: inherit;
  width: inherit;
  height: inherit;
  overflow-y: scroll;
}

ul {
  list-style-type: none;
  padding: 0;
}

</style>