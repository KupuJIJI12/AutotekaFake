<template>
  <div class="wrp">
    <header class="wrp__header">
      <aside class="wrp__header__aside wrp__header__aside_l">
        <div class="wrp__header__logo-block">

        </div>
      </aside>
      <aside class="wrp__header__aside wrp__header__aside_r">
        <nav class="wrp__header__nav">
          <ul>
            <li class="wrp__header__nav__item">
              <LinkButton value="Отчёты" />
            </li>
            <li class="wrp__header__nav__item">
              <LinkButton value="О сайте" />
            </li>
            <li class="wrp__header__nav__item">
              <LinkButton value="Контакты" />
            </li>
            <li class="wrp__header__nav__item wrp__header__nav__item_signin">
              <LinkButton value="Войти" />
            </li>
          </ul>
        </nav>
      </aside>
    </header>
    <router-view class="wrp__main"></router-view>
    <footer class="wrp__footer"></footer>
  </div>
</template>

<script setup lang="ts">
import LinkButton from "@/components/LinkButton.vue";

</script>

<style scoped lang="scss">

.wrp {
  width: 100vw;
  height: 100vh;
  background: linear-gradient(45deg, #2F4258, #436C71, #67C393);

  &__header {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;

    &__aside {
      margin: 7px 10px;
    }

    &__logo-block {
      color: white;
      display: flex;
      align-items: center;

      label {
        margin-left: 15px;
      }
    }

    &__nav {

      ul {
        display: flex;
      }

      &__item {
        margin: 0 15px;
        text-decoration: none;
        list-style-type: none;
      }

      &__item_signin {
        margin-left: 80px;

        button {
          border: 1px solid white;

          &:hover {
            background-color: #436573;
            border: none;
          }
        }
      }
    }
  }

  &__main {
    height: 80%;
  }

  &__footer {

  }
}

</style>
