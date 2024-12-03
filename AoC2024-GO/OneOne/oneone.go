package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
	"strconv"
	"strings"
)

func abs(x int) int {
	if x < 0 {
		return -x
	}
	return x
}

func main() {
	maxValue := 0

	file, _ := os.Open("../../Data2024/DayOneData.txt")
	defer file.Close()

	scanner := bufio.NewScanner(file)

	var leftNumbers []int
	var rightNumbers []int

	for scanner.Scan() {
		text := scanner.Text()
		parts := strings.SplitN(text, "   ", 2)
		left, _ := strconv.Atoi(parts[0])
		leftNumbers = append(leftNumbers, left)
		right, _ := strconv.Atoi(parts[1])
		rightNumbers = append(rightNumbers, right)
	}

	sort.Ints(leftNumbers)
	sort.Ints(rightNumbers)

	for i := 0; i < len(leftNumbers); i++ {
		maxValue += abs(leftNumbers[i] - rightNumbers[i])
	}

	fmt.Println(maxValue)
}
