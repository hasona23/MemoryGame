window.themeManager = {
    initTheme: function () {
        let theme = localStorage.getItem("theme") || "light"; // Default to light
        document.documentElement.setAttribute("data-bs-theme", theme);
        themeManager.updateIcon(theme);
    },
    toggleTheme: function () {
        let currentTheme = document.documentElement.getAttribute("data-bs-theme");
        let newTheme = currentTheme === "light" ? "dark" : "light";

        document.documentElement.setAttribute("data-bs-theme", newTheme);
        localStorage.setItem("theme", newTheme);
        themeManager.updateIcon(newTheme);
    },
    updateIcon: function (theme) {
        let icon = document.getElementById("themeIcon");
        if (icon) {
            
            icon.className = icon.className.replace(theme !== "dark" ? "fas fa-moon" : "fas fa-sun", theme === "dark" ? "fas fa-moon" : "fas fa-sun");
        }
    }
};

// Initialize theme on page load
document.addEventListener("DOMContentLoaded", themeManager.initTheme);
