﻿// script.js
function showModal(modalId) {
    var modalEl = document.getElementById(modalId);
    if (!modalEl) {
        console.error("Modal element not found: " + modalId);
        return;
    }
    var modalInstance = new bootstrap.Modal(modalEl, { backdrop: true });
    modalInstance.show();
}

window.initializeLineChart = (canvasId, chartData, chartOptions) => {
    // Get the canvas element using the provided ID
    var ctx = document.getElementById(canvasId).getContext('2d');
    // Create a new Chart.js chart (make sure Chart.js is loaded)
    new Chart(ctx, {
        type: 'line',
        data: chartData,
        options: chartOptions
    });
};

function typeWriterEffect(elementId, text, delay = 50) {
    const element = document.getElementById(elementId);
    if (!element) {
        console.error("Element with id '" + elementId + "' not found.");
        return;
    }
    element.innerHTML = ''; // Clear any existing content
    let i = 0;
    function typeNext() {
        if (i < text.length) {
            element.innerHTML += text.charAt(i);
            i++;
            setTimeout(typeNext, delay);
        }
        else {
            element.style.borderRight = 'none';
        }
    }
    typeNext();
}
document.addEventListener("DOMContentLoaded", function () {
    // Wait 1 second before starting the effect
    setTimeout(() => {
        typeWriterEffect(
            "typewriter",
            "Empowering Continuous Delivery, Automation, and Cloud Scalability with Modern DevOps Practices.",
            40 // Increase delay to 150ms between characters
        );
    }, 250);
});