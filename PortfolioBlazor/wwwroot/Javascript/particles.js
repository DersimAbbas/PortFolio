﻿window.loadParticles = () => {
    if (typeof particlesJS !== 'undefined') {
        particlesJS.load('particles-js', '/particles.json', function () {
            console.log('particles.js loaded successfully');
        });
    } else {
        console.error('particlesJS is not defined');
    }
};

window.loadClouds = () => {
    if (typeof particlesJS !== 'undefined') {
        particlesJS.load('cloud-js', '/cloud.json', function () {
            console.log('particles.js loaded successfully');
        });
    } else {
        console.error('particlesJS is not defined');
    }
};