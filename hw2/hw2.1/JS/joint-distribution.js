function handleFileSelect(event) {
    const file = event.target.files[0];
    const reader = new FileReader();

    reader.onload = function (e) {
        const data = e.target.result;
        processData(data);
    };

    reader.readAsText(file);
}

function processData(data) {
    const lines = data.split('\n');
    const ageCounts = new Map();
    const sexCounts = new Map();
    const total = lines.length - 1; // Subtract 1 to exclude the header

    // Calculate absolute frequencies
    for (let i = 1; i < lines.length; i++) {
        const [age, sex] = lines[i].split('	');
        ageCounts.set(age, (ageCounts.get(age) || 0) + 1);
        sexCounts.set(sex, (sexCounts.get(sex) || 0) + 1);
    }

    // Create the table
    const tableBody = document.getElementById('tableBody');
    tableBody.innerHTML = '';

    ageCounts.forEach((ageCount, age) => {
        sexCounts.forEach((sexCount, sex) => {
            const relativeFrequency = (ageCount / total) * (sexCount / total);
            const percentageDistribution = (relativeFrequency * 100).toFixed(2);

            const row = document.createElement('tr');
            row.innerHTML = `
                <td>${age}</td>
                <td>${sex}</td>
                <td>${ageCount * sexCount}</td>
                <td>${relativeFrequency.toFixed(4)}</td>
                <td>${percentageDistribution}%</td>
            `;
            tableBody.appendChild(row);
        });
    });
}