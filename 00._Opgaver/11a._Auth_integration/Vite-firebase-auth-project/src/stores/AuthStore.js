import { ref } from 'vue'
import { defineStore } from 'pinia'
import {
    getAuth,
    setPersistence,
    signInWithEmailAndPassword,
    browserSessionPersistence,
    browserLocalPersistence,
    signOut,
    createUserWithEmailAndPassword,
    onAuthStateChanged,
    sendEmailVerification,
    signInWithPopup,
    GoogleAuthProvider
} from 'firebase/auth'

export const useAuthStore = defineStore('authStore', () => {
    const errMsg = ref("")
    const isLoggedIn = ref(false)
    const loadingSession = ref(true)
    const rememberMe = ref(false)

    const auth = getAuth()
    const user = ref("")
    const provider = new GoogleAuthProvider();

    function loginWithGoogle() {
        let persistenceType = browserSessionPersistence
        if (rememberMe.value) {
            persistenceType = browserLocalPersistence
        } else {
            persistenceType = browserSessionPersistence
        }
        setPersistence(auth, persistenceType)
            .then(() => {
                return signInWithPopup(auth, provider)
                    .then((result) => {
                        isLoggedIn.value = true
                        errMsg.value = null
                        user.value = result.currentUser
                        if (user.value.emailVerified) {
                            isLoggedIn.value = true
                        } else {
                            errMsg.value = 'Please verify your email address'
                            signOut(auth)
                            isLoggedIn.value = false
                        }
                    })
                    .catch((error) => {
                        errMsg.value = error.message
                        const email = error.customData.email
                        const credential = GoogleAuthProvider.credentialFromError(error)
                    })
            })
            .catch((error) => {
                errMsg.value = error.message
            })
    }


    function loginUser(email, password) {
        let persistenceType = browserSessionPersistence
        if (rememberMe.value) {
            persistenceType = browserLocalPersistence
        } else {
            persistenceType = browserSessionPersistence
        }
        setPersistence(auth, persistenceType)
            .then(() => {
                return signInWithEmailAndPassword(auth, email, password)
                    .then((result) => {
                        isLoggedIn.value = true
                        errMsg.value = null
                        user.value = result.currentUser
                        if (user.value.emailVerified) {
                            isLoggedIn.value = true
                        } else {
                            errMsg.value = 'Please verify your email address'
                            signOut(auth)
                            isLoggedIn.value = false
                        }
                    })
                    .catch((error) => {
                        switch (error.code) {
                            case 'auth/invalid-email':
                                errMsg.value = 'Invalid email'
                                break
                            case 'auth/user-not-found':
                                errMsg.value = 'No account with that email was found'
                                break
                            case 'auth/wrong-password':
                                errMsg.value = 'Incorrect password'
                                break
                            case 'auth/missing-password':
                                errMsg.value = 'Missing password'
                                break
                            case 'auth/invalid-login-credentials':
                                errMsg.value = 'Invalid login credentials'
                                break
                            default:
                                errMsg.value = 'Email or password was incorrect'
                                break
                        }
                    })
            })
            .catch((error) => {
                errMsg.value = error.message
            })
    }

    function registerUser(email, password) {
        let persistenceType = browserSessionPersistence
        if (rememberMe.value) {
            persistenceType = browserLocalPersistence
        } else {
            persistenceType = browserSessionPersistence
        }
        setPersistence(auth, persistenceType)
            .then(() => {
                return createUserWithEmailAndPassword(auth, email, password)
                    .then((data) => {
                        isLoggedIn.value = true
                        errMsg.value = null
                        user.value = auth.currentUser
                        if (user.value.emailVerified) {
                            isLoggedIn.value = true
                        } else {
                            errMsg.value = 'Please verify your email address'
                            signOut(auth)
                            isLoggedIn.value = false
                        }
                        sendEmailVerification(data.user)
                    })
                    .catch((error) => {
                        switch (error.code) {
                            case 'auth/invalid-email':
                                errMsg.value = 'Invalid email'
                                break
                            case 'auth/missing-password':
                                errMsg.value = 'Missing password'
                                break
                            case 'auth/weak-password':
                                errMsg.value = 'Password is too weak'
                                break
                            default:
                                errMsg.value = 'Email already in use'
                                break
                        }
                    })
            })
            .catch((error) => {
                errMsg.value = error.message
            })
    }

    function signOutUser() {
        signOut(auth)
            .then(() => {
                isLoggedIn.value = false
                errMsg.value = null
            })
            .catch((error) => {
                errMsg.value = error.message
            })
        user.value = null
        isLoggedIn.value = false
    }

    onAuthStateChanged(auth, (currentUser) => {
        loadingSession.value = true
        if (currentUser) {
            user.value = currentUser
            if (user.value.emailVerified) {
                isLoggedIn.value = true
            } else {
                errMsg.value = 'Please verify your email address'
                signOut(auth)
                isLoggedIn.value = false
            }
            isLoggedIn.value = true
        } else {
            user.value = null
            errMsg.value = null
            isLoggedIn.value = false
        }
        loadingSession.value = false
    })

    return {
        user,
        errMsg,
        isLoggedIn,
        loadingSession,
        rememberMe,
        loginWithGoogle,
        loginUser,
        registerUser,
        signOutUser
    }
})