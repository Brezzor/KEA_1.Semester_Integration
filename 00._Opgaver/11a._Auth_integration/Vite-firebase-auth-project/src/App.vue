<script setup>
import { ref, computed } from 'vue'
import { useAuthStore } from './stores/AuthStore'
const authStore = useAuthStore()
const email = ref('')
const password = ref('')
const showPassword = ref(false)
const toggleShowPassword = () => {
  showPassword.value = !showPassword.value
}
const inputType = computed(() => {
  return showPassword.value ? 'text' : 'password'
})
</script>

<template>
  <header>
    <div class="wrapper">
      <div class="card">
        <div class="card-header">
          <h1>Firebase Auth</h1>
          <h2 v-if="!authStore.isLoggedIn">Login or Register</h2>
          <div v-else>
            <h2>Welcome</h2>
            <p>{{ authStore.user.email }}</p>
          </div>
        </div>
        <div class="card-body">
          <div v-if="!authStore.isLoggedIn">
            <label for="email">Email</label>
            <input type="email" v-model="email" placeholder="Email" />
            <label for="password">Password</label>
            <div class="password-input">
              <input :type="inputType" v-model="password" placeholder="Password" />
              <button v-on:click="toggleShowPassword">
                {{ showPassword ? 'Hide' : 'Show' }}
              </button>
            </div>
            <input type="checkbox" v-model="authStore.rememberMe" />
          </div>
          <p class="error-message">{{ authStore.errMsg }}</p>
        </div>
        <div class="card-footer">
          <div v-if="!authStore.isLoggedIn">
            <div class="buttons">
              <button v-on:click="authStore.loginUser(email, password)">Login</button>
              <button v-on:click="authStore.registerUser(email, password)">Register</button>
              <button v-on:click="authStore.loginWithGoogle">Login with Google</button>
            </div>
          </div>
          <div v-else>
            <button v-on:click="authStore.signOutUser">Logout</button>
          </div>
        </div>
      </div>
    </div>
  </header>

  <RouterView />
</template>

<style scoped></style>
