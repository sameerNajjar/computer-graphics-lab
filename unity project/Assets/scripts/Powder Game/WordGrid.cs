using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;
using System.Collections;
public class WordGrid : MonoBehaviour {
    [SerializeField] private GameObject currentElemnt;
    [SerializeField] private int xSize = 80;
    [SerializeField] private int ySize = 20;
    [SerializeField] private int zSize = 80;
    private GameObject[,,] cubeGrid;
    [SerializeField] private GameObject sand;
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject snow;
    [SerializeField] private GameObject lava;
    [SerializeField] private GameObject smoke;
    [SerializeField] private GameObject acid;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject cloud;
    [SerializeField] private GameObject oil;

    [SerializeField] private float spawnRate = 0.1f;
    private float spawnTimer = 0f;
    private bool isMouseDown = false;
    [SerializeField] private float moveDelay = 0.4f;
    private float moveTimer = 0f;


    private void Start() {
        cubeGrid = new GameObject[xSize, ySize, zSize];
    }

    private void Update() {
        handleInput();
        for (int x = 0; x < xSize; x++) {
            for (int y = 0; y < ySize; y++) {
                for (int z = 0; z < zSize; z++) {
                    if (cubeGrid[x, y, z] != null) {
                        if (cubeGrid[x, y, z].name == ("Sand(Clone)")) {
                            CellBehavior(x, y, z, 0);
                            continue;
                        }
                        if (cubeGrid[x, y, z].name == ("Water(Clone)")) {
                            CellBehavior(x, y, z, 1);
                            continue;
                        }
                        if (cubeGrid[x, y, z].name == ("Lava(Clone)")) {
                            ElemntsInteract(x, y, z, 2);
                            CellBehavior(x, y, z, 2);
                            continue;
                        }
                        if (cubeGrid[x, y, z].name == ("Snow(Clone)")) {
                            CellBehavior(x, y, z, 3);
                            continue;
                        }
                    }
                }
            }
        }
    }
    private void ElemntsInteract(int x, int y, int z, int cellType) {
        Vector3Int[] neighborOffsets = new Vector3Int[]
        {
        new Vector3Int(x - 1, y, z),   // Left
        new Vector3Int(x + 1, y, z),   // Right
        new Vector3Int(x, y, z - 1),   // Front
        new Vector3Int(x, y, z + 1),   // Back
        new Vector3Int(x, y - 1, z),   // Bottom
        new Vector3Int(x, y + 1, z)    // Top
        };

        foreach (Vector3Int offset in neighborOffsets) {
            int neighborX = offset.x;
            int neighborY = offset.y;
            int neighborZ = offset.z;

            if (IsInBounds(neighborX, neighborY, neighborZ) && cubeGrid[neighborX, neighborY, neighborZ] != null) {
                if (cellType == 2 && cubeGrid[neighborX, neighborY, neighborZ].name == "Water(Clone)") {
                    // Lava and water destroy each other
                    Destroy(cubeGrid[neighborX, neighborY, neighborZ]);
                    Destroy(cubeGrid[x, y, z]);
                }
                if (cellType == 2 && cubeGrid[neighborX, neighborY, neighborZ].name == "Snow(Clone)") {
                    // Lava and snow destroy each other and create water
                    Destroy(cubeGrid[neighborX, neighborY, neighborZ]);
                    Destroy(cubeGrid[x, y, z]);
                    Vector3 cubePosition = new Vector3(neighborX, neighborY, neighborZ);
                    GameObject cube = Instantiate(water, cubePosition, Quaternion.identity);
                    cubeGrid[neighborX, neighborY, neighborZ] = cube;
                    Debug.Log("sdf");
                }
            }
        }
    }
    private IEnumerator DelayedDestroy(int x, int y, int z, int neighborX, int neighborY, int neighborZ, int celltype) {
        yield return new WaitForSeconds(2f);
        Destroy(cubeGrid[neighborX, neighborY, neighborZ]);
        Destroy(cubeGrid[x, y, z]);
        if (celltype == 1) {
            Vector3 cubePosition = new Vector3(neighborX, neighborY, neighborZ);
            GameObject cube = Instantiate(water, cubePosition, Quaternion.identity);
            cubeGrid[neighborX, neighborY, neighborZ] = cube;
        }
    }
    private IEnumerator MeltSnowAndCreateWater(GameObject snow) {
        yield return new WaitForSeconds(5f); // Wait for 15 seconds
        if (snow != null) {// Destroy the snow cell
            int x = (int)snow.transform.position.x;
            int y = (int)snow.transform.position.y;
            int z = (int)snow.transform.position.z;
            Destroy(cubeGrid[x, y, z]);
            // Create a water cell at the same position
            Vector3 cubePosition = new Vector3(x, y, z);
            GameObject cube = Instantiate(water, cubePosition, Quaternion.identity);
            cubeGrid[x, y, z] = cube;
        }
    }

    private void CellBehavior(int x, int y, int z, int cellType) {
        if (y >= 1) {
            if ((((cubeGrid[x, y - 1, z] == null) || (cubeGrid[x, y - 1, z].name == ("Water(Clone)") && cellType == 0)))) {
                MoveCubeDown(x, y, z, x, y - 1, z);
                return;
            }
        }
        Vector3Int[] neighborOffsets = null;
        if (cellType == 0 || cellType == 3) {// sand and ice
            neighborOffsets = new Vector3Int[]
            {
                new Vector3Int(-1, -3, 1),    // Left
                new Vector3Int(-1, -3, 0),     // Right
                new Vector3Int(-1, -3, -1),    // Back
                new Vector3Int(0, -3, 1),     // Front
                new Vector3Int(0, -3, -1),   // Bottom Left
                new Vector3Int(1, -3, 1),    // Bottom Right
                new Vector3Int(1, -3, 0),    // Bottom Right
                new Vector3Int(1, -3, -1),    // Bottom Right
            };
        }
        else if (cellType == 1 || cellType == 2) { // water and lava
            neighborOffsets = new Vector3Int[]
            {
                new Vector3Int(-1, 0, 1),    // Left
                new Vector3Int(-1, 0, 0),     // Right
                new Vector3Int(-1, 0, -1),    // Back
                new Vector3Int(0, 0, 1),     // Front
                new Vector3Int(0, 0, -1),   // Bottom Left
                new Vector3Int(1, 0, 1),    // Bottom Right
                new Vector3Int(1, 0, 0),    // Bottom Right
                new Vector3Int(1, 0, -1),    // Bottom Right
            };
        }
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
            moveTimer -= Time.deltaTime;
            if (moveTimer <= 0f) {
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
                int targetX = x + selectedOffset.x;
                int targetY = y + selectedOffset.y;
                int targetZ = z + selectedOffset.z;
                MoveCubeDown(x, y, z, targetX, targetY, targetZ);
                moveTimer = moveDelay;
            }
        }
    }
    private void MoveCubeDown(int startX, int startY, int startZ, int targetX, int targetY, int targetZ) {
        GameObject cube = cubeGrid[startX, startY, startZ];
        cubeGrid[startX, startY, startZ] = cubeGrid[targetX, targetY, targetZ];
        cubeGrid[targetX, targetY, targetZ] = cube;
        if (cube != null) {
            Vector3 cubePosition = new Vector3(targetX, targetY, targetZ);
            cube.transform.position = cubePosition;
        }
    }
    private bool IsInBounds(int x, int y, int z) {
        return x >= 0 && x < xSize && y >= 0 && y < ySize && z >= 0 && z < zSize;
    }
    private void handleInput() {
        if (Input.GetMouseButtonDown(0)) {
            isMouseDown = true;
        }
        else if (Input.GetMouseButtonUp(0)) {
            isMouseDown = false;
        }

        if (isMouseDown) {
            spawnTimer -= Time.deltaTime;

            if (spawnTimer <= 0f) {
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
                            if (cubeGrid[x, y, z].name == "Snow(Clone)") {
                                StartCoroutine(MeltSnowAndCreateWater(cubeGrid[x, y, z]));
                            }
                        }
                    }
                }
                spawnTimer = spawnRate;
            }
        }
    }
    public void HandleButtonClick() {
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if (clickedButton.name == ("Sand Button")) {
            currentElemnt = sand;
        }
        else if ((clickedButton.name == ("Water Button"))) {
            currentElemnt = water;
        }
        else if ((clickedButton.name == ("Snow Button"))) {
            currentElemnt = snow;
        }
        else if ((clickedButton.name == ("lava Button"))) {
            currentElemnt = lava;
        }
        else if ((clickedButton.name == ("Acid Button"))) {
            currentElemnt = acid;
        }
        else if ((clickedButton.name == ("Stone Button"))) {
            currentElemnt = stone;
        }
        else if ((clickedButton.name == ("Smoke Button"))) {
            currentElemnt = smoke;
        }
        else if ((clickedButton.name == ("Fire Button"))) {
            currentElemnt = fire;
        }
        else if ((clickedButton.name == ("Oil Button"))) {
            currentElemnt = oil;
        }
        else if ((clickedButton.name == ("Cloud Button"))) {
            currentElemnt = cloud;
        }
    }
    public void ClearGrid() {
        for (int x = 0; x < xSize; x++) {
            for (int y = 0; y < ySize; y++) {
                for (int z = 0; z < zSize; z++) {
                    Destroy(cubeGrid[x, y, z]);
                }
            }
        }
    }
}
