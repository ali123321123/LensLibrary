# LensLibrary

**Advent of Code**  

*Contributor: MHD Ali Zedan ⭐

### Current Year: 2023

**Our sponsors help make Advent of Code possible:**
- Ximedes - Software for payments and public transport across the world

---

## Day 15: Lens Library

**Location:** Lava Production Facility on Lava Island

**Objective:**
- Bring the Lava Production Facility online using the Holiday ASCII String Helper (HASH) algorithm.

**Story:**
You find yourself at a facility on Lava Island, greeted by a reindeer in protective gear. The facility collects light from a parabolic reflector dish to power its operations.

### The HASH Algorithm
The HASH algorithm turns any string of characters into a number between 0 to 255. To use the HASH algorithm:
1. Start with a current value of 0.
2. For each character in the string:
   - Find the ASCII code for the character.
   - Add the ASCII code to the current value.
   - Multiply the current value by 17.
   - Set the current value to the remainder of itself divided by 256.

*Example*: Running HASH on "HASH" results in 52.

### Initialization Sequence
- The sequence is a comma-separated list of steps.
- Each step modifies the state of the Lava Production Facility.

**Example Sequence:**
rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7


**Task:**
Run the HASH algorithm on each step and sum the results.  
*Your puzzle answer was 498538.*

---

## Part Two

**Objective:**
- Organize 256 boxes to correctly focus light through lenses.
- Use the HASHMAP (Holiday ASCII String Helper Manual Arrangement Procedure) for each step.

**Box Setup:**
- 256 boxes numbered 0 through 255.
- Each box has lens slots for focusing light.

**Procedure:**
- Follow the sequence of letters for each step.
- Determine the correct box based on the HASH algorithm.
- Perform the operation indicated by the equals sign (=) or dash (-).

**Example Initialization:**



**Task:**
Calculate the focusing power of the resulting lens configuration.  
*Your puzzle answer was 286278.*



---

*Return to your Advent calendar or try another puzzle.*


