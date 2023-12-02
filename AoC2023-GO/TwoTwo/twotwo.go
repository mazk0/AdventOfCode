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
		maxRed := 0
		maxGreen := 0
		maxBlue := 0

		for _, round := range rounds {
			scores := strings.Split(strings.Trim(round, " "), " ")

			for i := 0; i < len(scores)/2; i++ {
				score := scores[2*i : 2+2*i]
				color := strings.TrimSuffix(score[1], ",")
				number, _ := strconv.Atoi(score[0])

				if color == "red" && number > maxRed {
					maxRed = number
					continue
				}

				if color == "green" && number > maxGreen {
					maxGreen = number
					continue
				}

				if color == "blue" && number > maxBlue {
					maxBlue = number
					continue
				}
			}
		}

		maxValue += maxRed * maxGreen * maxBlue
	}

	if err := scanner.Err(); err != nil {
		fmt.Print(err)
	}

	fmt.Println(maxValue)
}
