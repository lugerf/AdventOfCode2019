import math

input = []
alternative_input = [100756]

with open("input_day1.txt") as f:
    for line in f:
        input.append(int(line))


def calc_fuel(input_list):
    result = 0
    for mass in input_list:
        result = result + ((math.floor(mass / 3)) - 2)
    return result


def calc_fuel_detailes(input_list):
    return [((math.floor(mass / 3)) - 2) for mass in input_list]


def calc_fuel_for_fuel(input):
    result = 0
    last_calculated_fuel = input
    while last_calculated_fuel >= 0:
        fuel_to_add = math.floor(last_calculated_fuel / 3) - 2
        if fuel_to_add > 0:
            result = result + fuel_to_add
        last_calculated_fuel = fuel_to_add
    return result


result_stepOne_detailed = calc_fuel_detailes(input)
result_additional_fuel_per_module = [
    calc_fuel_for_fuel(x) for x in result_stepOne_detailed
]

final_result = sum(result_stepOne_detailed) + sum(result_additional_fuel_per_module)

print(f"Result: {final_result}")

