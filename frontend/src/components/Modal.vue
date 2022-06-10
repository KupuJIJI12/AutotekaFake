<template>
  <div class="modal" @click="closeModal">
    <div class="modal-container" @click="(e) => e.stopPropagation()">
      <h4 class="modal-header">{{header}}</h4>
      <div class="modal-content">
        <slot></slot>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Modal",
  props: {
    header: String
  },
  methods: {
    closeModal(){
      this.$emit('closeModal');
    }
  }
};
</script>

<style lang="scss" scoped>
.modal{
  position: fixed;
  width: 100vw;
  height: 100vh;
  display: flex;
  top: 0;
  left: 0;
  justify-content: center;
  align-items: center;
  background: rgba(0, 0, 0, 0.5);
  z-index: 2000;

  &-container{
    background-color: white;
    border-radius: 4px;
    max-width: 500px;
    max-height: 400px;
    z-index: 2001;
    padding: 0 15px 15px 15px;
  }

  &-content{

  }
}
</style>