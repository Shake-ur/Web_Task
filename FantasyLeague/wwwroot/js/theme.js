const themeToggle = document.getElementById("themeToggle");


// Load saved theme
const savedTheme = localStorage.getItem("theme");

if (savedTheme === "dark") {
    document.body.classList.add("dark-mode");

    themeToggle.textContent = "☀️ Light Mode";
}


// Toggle theme
themeToggle.addEventListener("click", function () {

    document.body.classList.toggle("dark-mode");

    const isDark = document.body.classList.contains("dark-mode");

    // Save user's choice
    localStorage.setItem(
        "theme",
        isDark ? "dark" : "light"
    );

    // Change button text
    themeToggle.textContent = isDark
        ? "☀️ Light Mode"
        : "🌙 Dark Mode";
});