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
                            <RouterLink to="/"> <img :src="logoSrc" alt="logo" width="124px" height="73px"></RouterLink>
                        </li>
                        <li class="nav-item col-8 d-flex justify-content-around align-items-center">
                          <RouterLink to="/food"> <div class="d-flex justify-content-start align-items-center gap-2">
                              <h6>Еда</h6>
                              <img :src="foodSrc" alt="food" width="63px" height="55px">
                            </div> </RouterLink>

                            <RouterLink to="/drinks"><div class="d-flex justify-content-center align-items-center gap-2">
                              <h6>Напитки</h6>
                              <img :src="drinkSrc" alt="drinks" width="59px" height="55px">
                            </div> </RouterLink>

                            <RouterLink to="/favorites"><div class="d-flex justify-content-end align-items-center gap-2">
                              <h6>Избранное</h6>
                              <img :src="favSrc" alt="favs" width="55px" height="55px">
                            </div> </RouterLink>
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
  border: 30px solid;
  border-image: url(../assets/border.png) 30;
  border-image-outset: 10px;
}

.router-link-exact-active,
.router-link-active {
  color: inherit; 
  text-decoration: none; 
}

a {
  color: inherit; 
  text-decoration: none; 
}
</style>
