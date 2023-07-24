using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;
using System.Collections;
using static UnityEditor.Experimental.GraphView.GraphView;
using TMPro;
public class WordGrid : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI output;
    [SerializeField] private GameObject currentElemnt;
    [SerializeField] private int xSize = 60;
    [SerializeField] private int ySize = 30;
    [SerializeField] private int zSize = 60;
    [SerializeField] private GameObject[,,] cubeGrid;
    [SerializeField] private GameObject sand;// 0
    [SerializeField] private GameObject water;// 1
    [SerializeField] private GameObject lava;// 2
    [SerializeField] private GameObject snow;// 3
    [SerializeField] private GameObject acid;// 4
    [SerializeField] private GameObject stone;// 5
    [SerializeField] private GameObject smoke;// 6
    [SerializeField] private GameObject fire;// 7
    [SerializeField] private GameObject oil;// 8
    [SerializeField] private GameObject cloud;// 9
    [SerializeField] private GameObject salt;// 10
    [SerializeField] private GameObject wood;// 11
    [SerializeField] private GameObject saltyWater;//12
    [SerializeField] private static int spawnNumber = 0;
    [SerializeField] private float spawnRate = 0.1f;
    private float spawnTimer = 0f;
    private bool isMouseDown = false;
    [SerializeField] private float moveDelay = 0.25f;
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
                        if (cubeGrid[x, y, z].name == ("Acid(Clone)")) {
                            ElemntsInteract(x, y, z, 4);
                            CellBehavior(x, y, z, 4);
                            continue;
                        }
                        if (cubeGrid[x, y, z].name == ("Stone(Clone)")) {
                            CellBehavior(x, y, z, 5);
                            continue;
                        }
                        if (cubeGrid[x, y, z].name == ("Smoke(Clone)")) {
                            CellBehavior(x, y, z, 6);
                            continue;
                        }
                        if (cubeGrid[x, y, z].name == ("Fire(Clone)")) {
                            ElemntsInteract(x, y, z, 7);
                            CellBehavior(x, y, z, 7);
                            continue;
                        }
                        if (cubeGrid[x, y, z].name == ("Oil(Clone)")) {
                            CellBehavior(x, y, z, 8);
                            continue;
                        }
                        if (cubeGrid[x, y, z].name == ("Cloud(Clone)")) {
                            CellBehavior(x, y, z, 9);
                            continue;
                        }
                        if (cubeGrid[x, y, z].name == ("Salt(Clone)")) {
                            ElemntsInteract(x, y, z, 10);
                            CellBehavior(x, y, z, 10);
                            continue;
                        }
                        if (cubeGrid[x, y, z].name == ("Wood(Clone)")) {
                            CellBehavior(x, y, z, 11);
                            continue;
                        }
                        if (cubeGrid[x, y, z].name == ("saltyWater(Clone)")) {
                            CellBehavior(x, y, z, 12);
                            ElemntsInteract(x, y, z, 12);
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
                if (cellType == 12) {//salty water 
                    if (cubeGrid[neighborX, neighborY, neighborZ].name == "Lava(Clone)" || cubeGrid[neighborX, neighborY, neighborZ].name == "Fire(Clone)") {
                        Destroy(cubeGrid[neighborX, neighborY, neighborZ]);
                        Destroy(cubeGrid[x, y, z]);
                        Vector3 cubePosition = new Vector3(neighborX, neighborY, neighborZ);
                        GameObject cube = Instantiate(cloud, cubePosition, Quaternion.identity);
                        StartCoroutine(destroyCounter(cube, 10, 9));
                        while (cubeGrid[neighborX, neighborY, neighborZ] != null) {
                            neighborY++;
                        }
                        cubeGrid[neighborX, neighborY, neighborZ] = cube;
                        cubePosition = new Vector3(x, y, z);
                        cube = Instantiate(salt, cubePosition, Quaternion.identity);
                        cubeGrid[x, y, z] = cube;
                    }
                    return;
                }
                if ((cellType == 1 || cellType==12)&& cubeGrid[neighborX, neighborY, neighborZ].name == "Salt(Clone)") {
                    Destroy(cubeGrid[x, y, z]);
                    Destroy(cubeGrid[neighborX, neighborY, neighborZ]);
                    Vector3 cubePosition = new Vector3(x, y, z);
                    cubeGrid[x, y, z] = Instantiate(saltyWater, cubePosition, Quaternion.identity);
                    return;
                }
                if(cellType==10&& cubeGrid[neighborX, neighborY, neighborZ].name == "Water(Clone)") {
                    Destroy(cubeGrid[x, y, z]);
                    Destroy(cubeGrid[neighborX, neighborY, neighborZ]);
                    Vector3 cubePosition = new Vector3(x, y, z);
                    cubeGrid[x, y, z] = Instantiate(saltyWater, cubePosition, Quaternion.identity);
                    return;
                }
                if ((cellType == 2 || cellType == 7 || cellType == 4) && cubeGrid[neighborX, neighborY, neighborZ].name == "Water(Clone)") {
                    // Lava,Fire and water destroy each other and create a cloud 
                    Destroy(cubeGrid[neighborX, neighborY, neighborZ]);
                    Destroy(cubeGrid[x, y, z]);
                    Vector3 cubePosition = new Vector3(neighborX, neighborY, neighborZ);
                    GameObject cube = Instantiate(cloud, cubePosition, Quaternion.identity);
                    StartCoroutine(destroyCounter(cube, 10, 9));
                    while (cubeGrid[neighborX, neighborY, neighborZ] != null) {
                        neighborY++;
                    }
                    cubeGrid[neighborX, neighborY, neighborZ] = cube;
                    return;
                }
                if ((cellType == 2 || cellType == 7) && cubeGrid[neighborX, neighborY, neighborZ].name == "Snow(Clone)") {
                    // Lava,Fire and snow destroy each other and create water
                    Destroy(cubeGrid[neighborX, neighborY, neighborZ]);
                    Destroy(cubeGrid[x, y, z]);
                    Vector3 cubePosition = new Vector3(neighborX, neighborY, neighborZ);
                    cubeGrid[neighborX, neighborY, neighborZ] = Instantiate(water, cubePosition, Quaternion.identity);
                    return;
                }
                if (cellType == 4) {
                    if (cubeGrid[neighborX, neighborY, neighborZ].name == "Snow(Clone)") {
                        Vector3 cubePosition = new Vector3(neighborX, neighborY, neighborZ);
                        cubeGrid[neighborX, neighborY, neighborZ] = Instantiate(water, cubePosition, Quaternion.identity);
                    }
                    else {
                        if (!(cubeGrid[neighborX, neighborY, neighborZ].name == "Acid(Clone)")) {
                            Destroy(cubeGrid[neighborX, neighborY, neighborZ]);
                            Destroy(cubeGrid[x, y, z]);
                            Vector3 cubePosition = new Vector3(neighborX, neighborY, neighborZ);
                            GameObject cube = Instantiate(smoke, cubePosition, Quaternion.identity);
                            StartCoroutine(destroyCounter(cube, 10, 6));
                            while (cubeGrid[neighborX, neighborY, neighborZ] != null) {
                                neighborY++;
                            }
                            cubeGrid[neighborX, neighborY, neighborZ] = cube;
                        }
                    }
                    return;
                }
                if (cellType == 7) {
                    if (cubeGrid[neighborX, neighborY, neighborZ].name == "Oil(Clone)" || cubeGrid[neighborX, neighborY, neighborZ].name == "Acid(Clone)"|| cubeGrid[neighborX, neighborY, neighborZ].name == "Wood(Clone)") {
                        Destroy(cubeGrid[neighborX, neighborY, neighborZ]);
                        Vector3 cubePosition = new Vector3(neighborX, neighborY, neighborZ);
                        cubeGrid[neighborX, neighborY, neighborZ] = Instantiate(fire, cubePosition, Quaternion.identity);
                        StartCoroutine(destroyCounter(cubeGrid[neighborX, neighborY, neighborZ], 10, 7));
                        GameObject cube = Instantiate(smoke, cubePosition, Quaternion.identity);
                        StartCoroutine(destroyCounter(cube, 10, 6));
                        while (cubeGrid[neighborX, neighborY, neighborZ] != null) {
                            neighborY++;
                        }
                        cubeGrid[neighborX, neighborY, neighborZ] = cube;
                        return;
                    }
                }
                if((cellType==7 || cellType==2)&& cubeGrid[neighborX, neighborY, neighborZ].name == "saltyWater(Clone)") {
                    Destroy(cubeGrid[neighborX, neighborY, neighborZ]);
                    Destroy(cubeGrid[x, y, z]);
                    Vector3 cubePosition = new Vector3(neighborX, neighborY, neighborZ);
                    GameObject cube = Instantiate(cloud, cubePosition, Quaternion.identity);
                    StartCoroutine(destroyCounter(cube, 10, 9));
                    while (cubeGrid[neighborX, neighborY, neighborZ] != null) {
                        neighborY++;
                    }
                    cubeGrid[neighborX, neighborY, neighborZ] = cube;
                    cubePosition = new Vector3(x, y, z);
                    cube = Instantiate(salt, cubePosition, Quaternion.identity);
                    cubeGrid[x, y, z] = cube;
                }
            }
        }
    }
    private IEnumerator destroyCounter(GameObject elemnt, int timer, int type) {
        yield return new WaitForSeconds(timer); // Wait 
        int x = (int)elemnt.transform.position.x;
        int y = (int)elemnt.transform.position.y;
        int z = (int)elemnt.transform.position.z;
        if (elemnt != null) {
            Destroy(cubeGrid[x, y, z]);
            if (type == 3 || type == 9) {// Create a water cell at the same position
                Vector3 cubePosition = new Vector3(x, y, z);
                cubeGrid[x, y, z] = Instantiate(water, cubePosition, Quaternion.identity);
            }
        }
    }

    private void CellBehavior(int x, int y, int z, int cellType) {
        if (IsInBounds(x, y + 1, z)) {
            if ((cellType == 6 || cellType == 9)) {//smoke and cloud
                MoveCube(x, y, z, x, y + 1, z);
            }
            if (((cellType == 8||cellType==11)) ){ // oil and wood  flow on water
                while ((IsInBounds(x, y + 1, z)&&(cubeGrid[x, y + 1, z]!=null)) && (cubeGrid[x, y + 1, z].name == ("Water(Clone)") || cubeGrid[x, y + 1, z].name == ("saltyWater(Clone)"))) {
                    MoveCube(x, y, z, x, y + 1, z);
                }
            }
        }
        if (IsInBounds(x, y - 1, z)) {
            if ((cubeGrid[x, y - 1, z] == null) && (cellType != 6 && cellType != 9)) {// every elemnt that isnt smoke and cloud moves down
                MoveCube(x, y, z, x, y - 1, z);
            }

            if ((cellType == 0 || cellType == 3 || cellType == 5 ) && (cubeGrid[x, y - 1, z].name == ("Water(Clone)") || (cubeGrid[x, y - 1, z].name == ("saltyWater(Clone)") || cubeGrid[x, y - 1, z].name == ("Oil(Clone)")))) {
                MoveCube(x, y, z, x, y - 1, z);
            }
        }
        if (cellType == 5 || cellType == 7 || cellType == 11) {// wood fire stone
            return;
        }
        Vector3Int[] neighborOffsets = null;
        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0f) {
            if (cellType == 0 || cellType == 3 || cellType == 10) {// sand  ice  salt
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
            else if (cellType == 1 || cellType == 2 || cellType == 4 || cellType == 6 || cellType == 8 || cellType == 9 || cellType == 12) { // water,lava,acid,smoke,oil,cloud move like fluid
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
                MoveCube(x, y, z, targetX, targetY, targetZ);
            }
            moveTimer = moveDelay;

        }
    }
    private void MoveCube(int startX, int startY, int startZ, int targetX, int targetY, int targetZ) {
        if (IsInBounds(startX, startY, startZ) && IsInBounds(targetX, targetY, targetZ)) {
            GameObject cube = cubeGrid[startX, startY, startZ];
            GameObject targetCube = cubeGrid[targetX, targetY, targetZ];
                cubeGrid[startX, startY, startZ] = targetCube;
                cubeGrid[targetX, targetY, targetZ] = cube;
                Vector3 cubePosition = new Vector3(targetX, targetY, targetZ);
            if (cube != null) {
                cube.transform.position = cubePosition;
            }
            if (targetCube!=null) {
                targetCube.transform.position = new Vector3(startX, startY, startZ);
            }
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
                            if (spawnNumber == 1) {
                                if (IsInBounds(x, y, z)){
                                    Vector3 cubePosition = new Vector3(x, y, z);
                                    cubeGrid[x, y, z] = Instantiate(currentElemnt, cubePosition, Quaternion.identity);
                                    AutuDestroy(cubeGrid[x, y, z]);
                                }
                            }
                            if (spawnNumber == 0) {
                                Vector3 cubePosition = new Vector3(x, y, z);
                                if (IsInBounds(x, y, z)) {
                                    cubeGrid[x, y, z] = Instantiate(currentElemnt, cubePosition, Quaternion.identity);
                                    AutuDestroy(cubeGrid[x, y, z]);
                                }
                                if (IsInBounds(x + 1, y, z)) {
                                    cubePosition = new Vector3(x + 1, y, z);
                                    cubeGrid[x + 1, y, z] = Instantiate(currentElemnt, cubePosition, Quaternion.identity);
                                    AutuDestroy(cubeGrid[x + 1, y, z]);
                                }
                                if (IsInBounds(x - 1, y, z)) {
                                    cubePosition = new Vector3(x - 1, y, z);
                                    cubeGrid[x - 1, y, z] = Instantiate(currentElemnt, cubePosition, Quaternion.identity);
                                    AutuDestroy(cubeGrid[x - 1, y, z]);
                                }
                                if (IsInBounds(x, y, z + 1)) {
                                    cubePosition = new Vector3(x, y, z + 1);
                                    cubeGrid[x, y, z + 1] = Instantiate(currentElemnt, cubePosition, Quaternion.identity);
                                    AutuDestroy(cubeGrid[x, y, z + 1]);
                                }
                                if (IsInBounds(x + 1, y, z + 1)) {
                                    cubePosition = new Vector3(x + 1, y, z + 1);
                                    cubeGrid[x + 1, y, z + 1] = Instantiate(currentElemnt, cubePosition, Quaternion.identity);
                                    AutuDestroy(cubeGrid[x + 1, y, z + 1]);
                                }
                                if (IsInBounds(x - 1, y, z + 1)) {
                                    cubePosition = new Vector3(x - 1, y, z + 1);
                                    cubeGrid[x - 1, y, z + 1] = Instantiate(currentElemnt, cubePosition, Quaternion.identity);
                                    AutuDestroy(cubeGrid[x - 1, y, z + 1]);
                                }
                                if (IsInBounds(x, y, z - 1)) {
                                    cubePosition = new Vector3(x, y, z - 1);
                                    cubeGrid[x, y, z - 1] = Instantiate(currentElemnt, cubePosition, Quaternion.identity);
                                    AutuDestroy(cubeGrid[x, y, z - 1]);
                                }
                                if (IsInBounds(x - 1, y, z - 1)) {
                                    cubePosition = new Vector3(x - 1, y, z - 1);
                                    cubeGrid[x - 1, y, z - 1] = Instantiate(currentElemnt, cubePosition, Quaternion.identity);
                                    AutuDestroy(cubeGrid[x - 1, y, z - 1]);
                                }
                                if (IsInBounds(x + 1, y, z - 1)) {
                                    cubePosition = new Vector3(x + 1, y, z - 1);
                                    cubeGrid[x + 1, y, z - 1] = Instantiate(currentElemnt, cubePosition, Quaternion.identity);
                                    AutuDestroy(cubeGrid[x + 1, y, z - 1]);
                                }
                            }
                        }
                    }
                    spawnTimer = spawnRate;
                }
            }
        }
    }

    public void AutuDestroy(GameObject cube) {
        if (cube.name == "Snow(Clone)") {
            StartCoroutine(destroyCounter(cube, 5, 3));
        }
        if (cube.name == "Acid(Clone)") {
            StartCoroutine(destroyCounter(cube, 5, 4));
        }
        if (cube.name == "Smoke(Clone)") {
            StartCoroutine(destroyCounter(cube, 10, 4));
        }
        if (cube.name == "Fire(Clone)") {
            StartCoroutine(destroyCounter(cube, 10, 7));
        }
        if (cube.name == "Cloud(Clone)") {
            StartCoroutine(destroyCounter(cube, 10, 9));
        }
    }
    public void HandleDropDown(int index) {
        spawnNumber = index;
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
        else if ((clickedButton.name == ("Salt Button"))) {
            currentElemnt = salt;
        }
        else if ((clickedButton.name == ("Wood Button"))) {
            currentElemnt = wood;
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
