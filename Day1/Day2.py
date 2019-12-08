# Init
input = []
result = 0

# Read in quest data:
with open("input_day2.txt") as f:
    for line in f:
        input.append(line.split(","))


class intcode:
    def __init__(self, *args, **kwargs):
        self.codes = {1: "ADD", 2: "MULTIPLY", 99: "STOP"}
        self.data = input


intcode_machine = intcode(input)

print(intcode_machine.data)
