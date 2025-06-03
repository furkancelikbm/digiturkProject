/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './Views/**/*.cshtml',
        './Pages/**/*.cshtml',
        './Components/**/*.cshtml', // View Component görünümleri için
        './wwwroot/**/*.{html,js}',
    ],
    theme: {
        extend: {},
    },
    plugins: [],
}