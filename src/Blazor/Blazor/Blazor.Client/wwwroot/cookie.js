window.cookieTools = {
    getCookie: function (name) {
        const cookies = document.cookie.split(';').map(c => c.trim());
        const target = cookies.find(c => c.startsWith(name + "="));
        if (!target) return null;
        return target.substring(name.length + 1);
    },

    setConsentCookie: function () {
        document.cookie = "consent=ok; max-age=31536000; path=/; SameSite=Lax";
    }
};
