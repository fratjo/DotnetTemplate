window.themeManager = {
    setTheme: (themeName) => {
        document.body.setAttribute('data-theme', themeName);
        localStorage.setItem('theme', themeName);
    },
    getTheme: () => {
        return localStorage.getItem('theme') || 'light';
    }
};