  // Set the target end date for countdown 
  const deadlineDate = document.getElementById("countdown").getAttribute("data-deadline");
  
  // Convert deadline date to a timestamp
  const targetDate = new Date(deadlineDate).getTime();

  function updateCountdown() {
    const now = new Date().getTime();
    const distance = targetDate - now;

    // Calculate time units
    const days = Math.floor(distance / (1000 * 60 * 60 * 24));
    const hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    const mins = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    const secs = Math.floor((distance % (1000 * 60)) / 1000);

    // Update the HTML elements
    document.getElementById("days").innerText = days < 10 ? '0' + days : days;
    document.getElementById("hours").innerText = hours < 10 ? '0' + hours : hours;
    document.getElementById("mins").innerText = mins < 10 ? '0' + mins : mins;
    document.getElementById("secs").innerText = secs < 10 ? '0' + secs : secs;

    // If countdown is over
    if (distance < 0) {
      clearInterval(countdownInterval);
      document.getElementById("days").innerText = "00";
      document.getElementById("hours").innerText = "00";
      document.getElementById("mins").innerText = "00";
      document.getElementById("secs").innerText = "00";
    }
  }

  // Update countdown every second
  const countdownInterval = setInterval(updateCountdown, 1000);