<template>
  <div>
    <span v-if="!raisePedanticism">
        Click on the Green button to get yer number!
    </span>
    <span v-if="raisePedanticism">
        Oh look what you've done to that poor table. Just click the Reset button already!
    </span>
  </div>
</template>

<script>
export default {
  name: 'PedanticBlurb',
  props: {
    raisePedanticism: Number
  }
}
</script>

<style scoped>

</style>