// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* === ADMIN ALERT AUTO-HIDE === */
// Function to auto-hide alert messages after 3 seconds
function autoHideAlert() {
    setTimeout(function () {
        var alert = document.getElementById('alertMsg');
        if (alert) {
            alert.style.transition = "opacity 0.5s ease";
            alert.style.opacity = "0";
            setTimeout(function () { 
                alert.remove(); 
            }, 500);
        }
    }, 3000);
}

/* === IMAGE PREVIEW FUNCTIONALITY === */
// Function to set up image preview for file inputs
function setupImagePreview() {
    const imageInput = document.getElementById('imageInput');
    if (imageInput) {
        imageInput.addEventListener('change', function (e) {
            const file = e.target.files[0];
            const preview = document.getElementById('imagePreview');
            const previewImg = document.getElementById('previewImg');

            if (file && preview && previewImg) {
                const reader = new FileReader();
                reader.onload = function (e) {
                    previewImg.src = e.target.result;
                    preview.style.display = 'block';
                };
                reader.readAsDataURL(file);
            } else if (preview) {
                preview.style.display = 'none';
            }
        });
    }
}

/* === INITIALIZATION === */
// Initialize functions when DOM is loaded
document.addEventListener('DOMContentLoaded', function() {
    // Auto-hide alerts (for admin area)
    autoHideAlert();
    
    // Setup image preview (for create/edit forms)
    setupImagePreview();
});
