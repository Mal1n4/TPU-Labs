<script setup lang="js">
  import logoSrc from '@/assets/little-pony-logo.png'
  import profileSrc from '@/assets/ava.jpg'
  import foodSrc from '@/assets/apple_pie.png'
  import drinkSrc from '@/assets/cider.png'
  import favSrc from '@/assets/apples.png'
</script>

<template>
  <nav class="navbar navbar-expand navbar-light">
            <div class="w-100 justify-content-center">
                <div class="container align-items-center justify-content-center">
                    <ul class="navbar-nav me-auto align-items-center">
                          <li class="nav-item col-2 ">
                            <img :src="logoSrc" alt="logo" width="124px" height="73px">
                        </li>
                        <li class="nav-item col-8 d-flex justify-content-around">
                            <div class="d-flex justify-content-start align-items-center">
                              <a class="nav-link active text-center" aria-current="page" href="#">Еда</a>
                              <img :src="foodSrc" alt="food" width="63px" height="53px">
                            </div>
                            <div class="d-flex justify-content-center align-items-center">
                              <a class="nav-link active text-center" aria-current="page" href="#">Напитки</a>
                              <img :src="drinkSrc" alt="drinks" width="59px" height="55px">
                            </div>
                            <div class="d-flex justify-content-end align-items-center">
                              <a class="nav-link active text-center" aria-current="page" href="#">Избранное</a>
                              <img :src="favSrc" alt="favs" width="55px" height="55px">
                            </div>
                        </li>
                        <li class="nav-item col-2 d-flex justify-content-end align-items-center">
                            <a class="nav-link active text-end" aria-current="page" href="#">Профиль</a>
                            <img :src="profileSrc" alt="profile" width="88px" height="55px">
                        </li>
                    </ul>
                </div>
            </div>
  </nav>
</template>

<style scoped>
nav {
  background-color: #FFF377;
  height: 90px;
  /* outline: 50px dotted;
  outline-offset: -30px;
  outline-color: #FFF377; */
}
</style>
