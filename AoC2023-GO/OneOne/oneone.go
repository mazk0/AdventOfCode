package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	file, err := os.Open("../../Data2023/DayOneData.txt")
	if err != nil {
		fmt.Print(err)
	}
	defer file.Close()

	scanner := bufio.NewScanner(file)

	maxValue := 0
	for scanner.Scan() {
		firstDigit := 0
		lastDigit := 0

		for i := 0; i < len(scanner.Text()); i++ {
			currentFirst := scanner.Text()[i]
			currentLast := scanner.Text()[len(scanner.Text())-1-i]

			if 48 < currentFirst && currentFirst < 58 && firstDigit == 0 {
				firstDigit = int(currentFirst) - 48
			}

			if 48 < currentLast && currentLast < 58 && lastDigit == 0 {
				lastDigit = int(currentLast) - 48
			}

			if firstDigit != 0 && lastDigit != 0 {
				maxValue += firstDigit*10 + lastDigit
				break
			}
		}
	}

	if err := scanner.Err(); err != nil {
		fmt.Print(err)
	}

	fmt.Println(maxValue)
}
