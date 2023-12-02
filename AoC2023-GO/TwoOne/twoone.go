package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func main() {
	file, err := os.Open("../../Data2023/DayTwoData.txt")
	if err != nil {
		fmt.Print(err)
	}

	defer file.Close()

	scanner := bufio.NewScanner(file)

	maxValue := 0
	for scanner.Scan() {
		game := strings.Split(scanner.Text(), ":")
		rounds := strings.Split(game[1], ";")
		isPossible := true
		for _, round := range rounds {
			scores := strings.Split(strings.Trim(round, " "), " ")

			for i := 0; i < len(scores)/2; i++ {
				score := scores[2*i : 2+2*i]
				color := strings.TrimSuffix(score[1], ",")
				number, _ := strconv.Atoi(score[0])

				if color == "red" && number > 12 {
					isPossible = false
					break
				}

				if color == "green" && number > 13 {
					isPossible = false
					break
				}

				if color == "blue" && number > 14 {
					isPossible = false
					break
				}
			}
		}

		if isPossible {
			round, _ := strconv.Atoi(strings.Split(game[0], " ")[1])
			maxValue += round
		}
	}

	if err := scanner.Err(); err != nil {
		fmt.Print(err)
	}

	fmt.Println(maxValue)
}
