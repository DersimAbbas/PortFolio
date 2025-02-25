// script.js
window.showModal = (modalId) => {
    var myModal = new bootstrap.Modal(document.getElementById(modalId));
    myModal.show();
};
window.hideModal = (modalId) => {
    var modalEl = document.getElementById(modalId);
    var modal = bootstrap.Modal.getInstance(modalEl);
    if (modal) {
        modal.hide();
    }
};
window.updateModalTitle = (newTitle) => {
  const titleEl = document.querySelector("#skillprogress .modal-title");
  if(titleEl) {
    titleEl.textContent = newTitle;
  }
};
    // Get the canvas element using the provided ID
window.initializeLineChart = (canvasId, chartData, chartOptions) => {
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



function animateProgress(target, duration) {
    var elem = document.getElementById("myBar");
    if (!elem) return;
    // Get the current width (parse percentage value)
    var start = parseFloat(elem.style.width) || 0;
    var diff = target - start;
    var startTime = null;

    function step(timestamp) {
        if (!startTime) startTime = timestamp;
        var elapsed = timestamp - startTime;
        var factor = elapsed / duration;
        if (factor > 1) factor = 1;
        var newWidth = start + diff * factor;
        elem.style.width = newWidth + "%";
        elem.setAttribute("aria-valuenow", newWidth);
        if (factor < 1) {
            requestAnimationFrame(step);
        }
    }
    requestAnimationFrame(step);
}

function resetProgressBar() {
    var elem = document.getElementById("myBar");
    if (elem) {
        elem.setAttribute("aria-valuenow", 0);
    }
}