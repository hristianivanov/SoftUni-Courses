function removeImageBackground(image) {
    return new Promise(function(resolve, reject) {
        const backgroundColor = { red: 255, green: 255, blue: 255 };
        const threshold = 10;

        const imageElement = new Image();

        // Set up event listeners
        imageElement.onload = function() {
            var canvas = document.createElement('canvas');
            canvas.width = imageElement.naturalWidth;
            canvas.height = imageElement.naturalHeight;

            var ctx = canvas.getContext('2d');
            ctx.drawImage(imageElement, 0, 0);
            const imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
            for (var i = 0; i < imageData.data.length; i += 4) {
                const red = imageData.data[i];
                const green = imageData.data[i + 1];
                const blue = imageData.data[i + 2];
                if (
                    Math.abs(red - backgroundColor.red) < threshold &&
                    Math.abs(green - backgroundColor.green) < threshold &&
                    Math.abs(blue - backgroundColor.blue) < threshold
                ) {
                    imageData.data[i + 3] = 0;
                }
            }

            ctx.putImageData(imageData, 0, 0);
            resolve(canvas.toDataURL('image/png'));
        };

        imageElement.onerror = function() {
            reject(new Error('Error loading image: ' + image));
        };

        imageElement.src = image;
    });
}

const imageUrl = 'https://thumbs.dreamstime.com/b/red-apple-isolated-white-background-45573196.jpg';

removeImageBackground(imageUrl)
    .then(function(result) {
        console.log('Background removed:', result);
        // Use the result as needed
    })
    .catch(function(error) {
        console.error('Error:', error.message);
        // Handle the error, if needed
    });
