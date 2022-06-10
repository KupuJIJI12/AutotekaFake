<template>
  <div class="info-block__content">
    <slot class="info-block__content_item"></slot>
  </div>
</template>

<style lang="scss">
.info-block__content {

  &_item:not(.info-block__content_item:last-child){
    border-bottom: 1px solid #e0e0e0;
    padding-bottom: 10px;
  }
}
</style>