using UnityEngine;
using UnityEngine.UI;

public class WordGrid : MonoBehaviour {
    [SerializeField] private GameObject currentElemnt; 
    [SerializeField] private int xSize = 20; 
    [SerializeField] private int ySize = 15; 
    [SerializeField] private int zSize = 20; 
    [SerializeField] private GameObject[,,] cubeGrid;
    [SerializeField] private GameObject sand;
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject snow;
    [SerializeField] private GameObject lava;


    private void Start() {
        cubeGrid = new GameObject[xSize, ySize, zSize];
    }

    private void Update() {
        handleInput();
            for (int x = 0; x < xSize; x++) {
            for (int y = 1; y < ySize; y++) {
                for (int z = 0; z < zSize; z++) {
                    // Check if the current point have an elemnt and call the Behavior functions
                    if (cubeGrid[x, y, z] != null) {
                        if (cubeGrid[x, y, z].CompareTag("sand")) {
                            SandBehavior(x, y, z);
                        }
                    }
                }
            }
        }
    }

    private void SandBehavior(int x, int y, int z) {
        // Check if the cube is at the bottommost layer
        if (y == 0)
            return;

        // Check if the cube below is empty
        if (cubeGrid[x, y - 1, z] == null) {
            MoveCubeDown(x, y, z, x, y - 1, z);
        }
        // If the cube below is not empty, apply the cellular automata rule
        else {
            // Define the neighboring coordinates
            Vector3Int[] neighborOffsets = new Vector3Int[]
            {
    new Vector3Int(-1, -1, 0),    // Left
    new Vector3Int(1, -1, 0),     // Right
    new Vector3Int(0, -1, -1),    // Back
    new Vector3Int(0, -1, 1),     // Front
    new Vector3Int(-1, -1, -1),   // Bottom Left
    new Vector3Int(1, -1, -1),    // Bottom Right
            };

            // Count the number of empty neighbors
            int emptyNeighborCount = 0;
            foreach (Vector3Int offset in neighborOffsets) {
                int neighborX = x + offset.x;
                int neighborY = y + offset.y;
                int neighborZ = z + offset.z;

                // Check if the neighbor is within bounds and empty
                if (IsInBounds(neighborX, neighborY, neighborZ) && cubeGrid[neighborX, neighborY, neighborZ] == null)
                    emptyNeighborCount++;
            }

            // If there are empty neighbors, move the cube randomly to one of them
            if (emptyNeighborCount > 0) {
                // Select a random empty neighbor
                int randomIndex = Random.Range(0, emptyNeighborCount);
                int emptyNeighborIndex = 0;
                Vector3Int selectedOffset = Vector3Int.zero;

                foreach (Vector3Int offset in neighborOffsets) {
                    int neighborX = x + offset.x;
                    int neighborY = y + offset.y;
                    int neighborZ = z + offset.z;

                    // Check if the neighbor is within bounds and empty
                    if (IsInBounds(neighborX, neighborY, neighborZ) && cubeGrid[neighborX, neighborY, neighborZ] == null) {
                        if (emptyNeighborIndex == randomIndex) {
                            selectedOffset = offset;
                            break;
                        }
                        emptyNeighborIndex++;
                    }
                }
                // Move the cube to the selected empty neighbor
                int targetX = x + selectedOffset.x;
                int targetY = y + selectedOffset.y;
                int targetZ = z + selectedOffset.z;
                MoveCubeDown(x, y, z, targetX, targetY, targetZ);
            }
        }
    }
    private void MoveCubeDown(int startX, int startY, int startZ, int targetX, int targetY, int targetZ) {
        cubeGrid[targetX, targetY, targetZ] = cubeGrid[startX, startY, startZ];
        cubeGrid[startX, startY, startZ] = null;
        Vector3 cubePosition = new Vector3(targetX, targetY, targetZ);
        cubeGrid[targetX, targetY, targetZ].transform.position = cubePosition;
    }
    private bool IsInBounds(int x, int y, int z) {
        return x >= 0 && x < xSize && y >= 0 && y < ySize && z >= 0 && z < zSize;
    }
    private void handleInput() {
        if (Input.GetMouseButtonDown(0)) {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {

                int x = Mathf.RoundToInt(hit.point.x);
                int z = Mathf.RoundToInt(hit.point.z);

                if (x >= 0 && x < xSize && z >= 0 && z < zSize) {
                    int y = ySize - 1; 
                    if (cubeGrid[x, y, z] == null || cubeGrid[x, y, z].GetComponent<BoxCollider>() == null) {
                        Vector3 cubePosition = new Vector3(x, y, z);
                        GameObject cube = Instantiate(currentElemnt, cubePosition, Quaternion.identity);
                        cubeGrid[x, y, z] = cube;
                    }
                }
            }
        }
    }
    public void HandleButtonClick() {
        // Get the button that called this method
        Debug.Log("button clicked");
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if (clickedButton.name==("Sand Button")) {
            currentElemnt = sand;
                }
        else if ((clickedButton.name==("Water Button"))) {
            currentElemnt = water;
        }
    }
}
