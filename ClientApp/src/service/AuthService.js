
export const AuthService = {
    isAuth,
    setExpireTimer,
    isAuthExpire,
    logout,
    token,
    handleResponse,
    user,
    setAuthUser
};

function isAuth() {
    const user = JSON.parse(localStorage.getItem('user'));
    if (user && user.token && user.token.length > 0 && (isAuthExpire() === false)) {
        return true;
    } else {
        return false;
    }
}

function setAuthUser(user) {
    localStorage.setItem('user', user);
    setExpireTimer();
}
function setExpireTimer() {
    const nowTime = new Date().getTime();
    const setUpTime = localStorage.getItem("setupTime");
    if (setUpTime === null) {
        localStorage.setItem('setupTime', nowTime);
    }
}

function isAuthExpire() {
    const hours = 24;
    const nowTime = new Date().getTime();
    const setUpTime = localStorage.getItem("setupTime");
    if (setUpTime === null) {
        localStorage.setItem('setupTime', nowTime);
        return true;
    } else if ((nowTime - setUpTime) > hours * 60 * 60 * 1000) {
        localStorage.clear();
        return true;
    } else {
        return false;
    }
}

function logout() {
    localStorage.removeItem("user");
}

function token() {
    const user = JSON.parse(localStorage.getItem("user"));
    return user.token;
}

function handleResponse(response) {
    
    switch (response) {
        case 200:
            this.props.history.push("/user");
            break;
        case 401:
            AuthService.authService.logout();
            this.props.history.push("/login");
            break;
    }
}

function user() {
    return JSON.parse(localStorage.getItem('user'));
}