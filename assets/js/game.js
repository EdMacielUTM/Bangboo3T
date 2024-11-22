document.addEventListener("DOMContentLoaded", function () {
    const grid = document.getElementById("grid");
    const player1Token = document.getElementById("player1-token");
    const player2Token = document.getElementById("player2-token");

    // Initialize the game variables
    let currentPlayer = 1;
    const columns = 7;
    const rows = 6;
    const board = Array.from({ length: rows }, () => Array(columns).fill(0));

    // Generate the grid dynamically
    for (let i = 0; i < rows * columns; i++) {
        const cell = document.createElement("div");
        cell.classList.add("cell");
        cell.dataset.column = i % columns;
        cell.dataset.row = Math.floor(i / columns);
        cell.addEventListener("dragover", allowDrop);
        cell.addEventListener("drop", dropToken);
        grid.appendChild(cell);
    }

    // Drag event handlers
    player1Token.addEventListener("dragstart", dragToken);
    player2Token.addEventListener("dragstart", dragToken);

    function allowDrop(event) {
        event.preventDefault();
    }

    function dragToken(event) {
        event.dataTransfer.setData("player", currentPlayer);
    }

    function dropToken(event) {
        event.preventDefault();
        const column = parseInt(event.target.dataset.column); // Ensure it's an integer
        const row = findEmptyRow(column);

        if (row !== -1) {
            board[row][column] = currentPlayer;
            const cell = document.querySelector(`.cell[data-row='${row}'][data-column='${column}']`);
            cell.classList.add(currentPlayer === 1 ? "player1" : "player2");
            
            if (checkWin(row, column)) {
                // SweetAlert to announce the winner
                Swal.fire({
                    title: `Player ${currentPlayer} Wins!`,
                    text: "Congratulations! Do you want to play again?",
                    icon: "success",
                    confirmButtonText: "Play Again"
                }).then(() => {
                    resetGame();
                });
                return;
            }

            // Switch players
            currentPlayer = currentPlayer === 1 ? 2 : 1;
        }
    }

    function findEmptyRow(column) {
        for (let row = rows - 1; row >= 0; row--) {
            if (board[row][column] === 0) return row;
        }
        return -1;
    }

    function checkWin(row, column) {
        const player = board[row][column];
    
        // Define all directions as pairs of row and column offsets
        const directions = [
            [0, 1],   // Horizontal (right and left)
            [1, 0],   // Vertical (down and up)
            [1, 1],   // Diagonal (bottom-right and top-left)
            [1, -1]   // Diagonal (bottom-left and top-right)
        ];
    
        for (const [rowDir, colDir] of directions) {
            const totalInLine = 1 + countConsecutiveTokens(row, column, rowDir, colDir, player) 
                                  + countConsecutiveTokens(row, column, -rowDir, -colDir, player);
            
            if (totalInLine >= 4) {
                // SweetAlert to announce the winner
                Swal.fire({
                    title: `Player ${player} Wins!`,
                    text: "Congratulations! Do you want to play again?",
                    icon: "success",
                    confirmButtonText: "Play Again"
                }).then(() => {
                    resetGame();
                });
                return true;
            }
        }
    
        return false;
    }
    
    // Helper function to count consecutive tokens in a specific direction
    function countConsecutiveTokens(row, column, rowDir, colDir, player) {
        let count = 0;
        let r = row + rowDir;
        let c = column + colDir;
        // Traverse in the specified direction
        while (r >= 0 && r < rows && c >= 0 && c < columns && board[r][c] === player) {
            count++;
            r += rowDir;
            c += colDir;
        }
        
        return count;
    }
    
    // Reset the game
    function resetGame() {
        board.forEach(row => row.fill(0));
        document.querySelectorAll(".cell").forEach(cell => {
            cell.classList.remove("player1", "player2");
        });
        currentPlayer = 1;
    }
});
