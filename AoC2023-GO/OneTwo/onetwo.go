package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

func main() {
	file, err := os.Open("../../Data2023/DayOneData.txt")
	if err != nil {
		fmt.Print(err)
	}
	defer file.Close()

	scanner := bufio.NewScanner(file)

	numbers := []string{"1", "2", "3", "4", "5", "6", "7", "8", "9", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"}

	maxValue := 0
	for scanner.Scan() {
		firstLowestIndex := len(scanner.Text())
		fistNumber := 0
		lastHighestIndex := -1
		lastNumber := 0

		for i := 1; i < len(numbers)+1; i++ {
			number := numbers[i-1]
			firstIndex := strings.Index(scanner.Text(), number)
			lastIndex := strings.LastIndex(scanner.Text(), number)

			if firstIndex == -1 || lastIndex == -1 {
				continue
			}

			if firstIndex < firstLowestIndex {
				firstLowestIndex = firstIndex
				if i > 9 {
					i -= 9
				}
				fistNumber = i
			}

			if lastIndex > lastHighestIndex {
				lastHighestIndex = lastIndex
				if i > 9 {
					i -= 9
				}
				lastNumber = i
			}
		}

		maxValue += fistNumber*10 + lastNumber
	}

	if err := scanner.Err(); err != nil {
		fmt.Print(err)
	}

	fmt.Println(maxValue)
}
