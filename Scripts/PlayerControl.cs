using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour {
	
	public float gravity = 1f;
	
	public float velocitySnap = 0.005f;
	public float dragX = 5f;
	public float dragY = 5f;
	
	public Vector2 topAccelerationVec = Vector2.one;
	public Vector2 topVelocityVec = Vector2.one;
	public float jumpMod = 2f;
	public float jumpTime = 0.25f;
	public float jumpHeight = 1f;
	public float airJumpMod = 0.5f;
	public float airArc = 0.5f;
	private float lastJump = 0f;
	
	
	public Vector2 currentVelocity = Vector2.zero;
	private Vector2 inputVec = Vector2.zero;
	
	private EntityMovement myEntityMovement;
	private CharacterController cc;
	
	private bool jumping = false;
	
	public bool horzStop;
	public LayerMask collisionMask;
	private int rayHeightDivisions = 3;
	public float baseRayDist = 5;
	private Ray ray;
	private RaycastHit hit;
	private float dist;
	private float dirX = 1;
	public float skin = 0.005f;
	private float midWidth;
	private float midHeight;
	public Character character;
	
	private bool DisplayInventory { get; set; }
	private bool DisplayEquipment { get; set; }
	
	void Start () {
		cc = transform.GetComponent<CharacterController>();
		character = new Character(200, 300, 400, 500);
		Debug.Log("Shield:" + character.Shield.Current);
		Debug.Log("Hull:" + character.Hull.Current);
		DisplayEquipment = false;
		DisplayInventory = false;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			character.TakeDamage(50f, 50f);
			Debug.Log("Shield:" + character.Shield.Current);
			Debug.Log("Hull:" + character.Hull.Current);
		}
		if(Input.GetKeyDown(KeyCode.F1)){
			//create item and equip it
			//character.EquipArmor(ItemGenerator.RandomHeadArmor(new Armor("Random Weapon Test", ITEMTYPE.ARMOR)) as Item);
			character.PickUp(ItemGenerator.RandomHeadArmor(new Armor("Random Weapon Test", ITEMTYPE.ARMOR)) as Item);
		}
		if(Input.GetKeyDown(KeyCode.F2)){
			Debug.Log("Shield:" + character.Shield.Current);
			Debug.Log("Hull:" + character.Hull.Current);
		}
		if(Input.GetKeyDown(KeyCode.I)){
			DisplayInventory = !DisplayInventory;
		}
		if(Input.GetKeyDown(KeyCode.Tab)){
			DisplayEquipment = !DisplayEquipment;
		}
		//1, 2, 3, 4, space, left shift, left mouse, right mouse
		if(Input.GetKeyDown(KeyCode.1)){
			
		}
		if(Input.GetKeyDown(KeyCode.2)){
		}
		if(Input.GetKeyDown(KeyCode.3)){
		}
		if(Input.GetKeyDown(KeyCode.4)){
		}
		if(Input.GetKeyDown(KeyCode.Space)){
		}
		if(Input.GetKeyDown(KeyCode.LeftShift)){
		}
		if(Input.GetMouseDown(0){//left mouse
		}
		if(Input.GetMouseDown(1){//right mouse
		}
		
		inputVec.x = Input.GetAxisRaw("Horizontal");
		inputVec.y = Input.GetAxisRaw("Vertical");
		
		Accelerate(inputVec);
		cc.Move(currentVelocity);
	}
	
	void Accelerate(Vector2 _inputVec){
		horzStop = false;
		midWidth = transform.position.x + cc.center.x;
		midHeight = transform.position.y + cc.center.y;
		
		if(_inputVec.x != 0){
			dirX = Mathf.Sign(_inputVec.x);
		}
		
		for(int j = 0; j < rayHeightDivisions; j++){
			ray = new Ray(new Vector3(midWidth + (dirX * cc.radius), midHeight - (cc.height / 2),  0), new Vector3(dirX,0,0));
			Debug.DrawRay(ray.origin,ray.direction.normalized * (Mathf.Abs(_inputVec.x) * baseRayDist  + 1), Color.red);
			if(Physics.Raycast(ray, out hit, Mathf.Abs(_inputVec.x) * baseRayDist + 1, collisionMask)){
				dist = Vector3.Distance(ray.origin, hit.point);
				if(dist < skin){
					horzStop = true;
					break;
				}
				if(dist < Mathf.Abs(_inputVec.x)){
					_inputVec.x = (dist - skin) * dirX;
					horzStop = true;//stop
					break;
				}
			}
		}
		if(horzStop){
			currentVelocity.x = 0;
		}else{
			currentVelocity.x += (inputVec.x != 0)? inputVec.x * topAccelerationVec.x * Time.deltaTime: -1 * currentVelocity.x * dragX * Time.deltaTime;
		}
		if(cc.isGrounded){
			currentVelocity.y = 0;
		}else{
			//add gravity
			currentVelocity.y -= gravity * Time.deltaTime;
		}
	}
	//Inventory stuff
	public Rect inventoryWindowRect = new Rect(20, 20, 200, 300);
	public Rect equipmentWindowRect = new Rect(20, 20, 200, 300);
	public Rect headSlotRect = new Rect(75, 30, 50, 50);
	public Rect torsoSlotRect = new Rect(75, 90, 50, 50);
	public Rect legsSlotRect = new Rect(75, 150, 50, 50);
	public Rect leftWeaponSlotRect = new Rect(20, 90, 50, 50);
	public float sideBuffer = 10;
	public float topBuffer = 20;
	public float inventoryRows = 5;
	public float inventoryCols = 4;
	void OnGUI(){
		if(DisplayInventory){
			inventoryWindowRect = GUI.Window(0, inventoryWindowRect, InventoryWindow, "Inventory");
		}
		if(DisplayEquipment){
			equipmentWindowRect = GUI.Window(1, equipmentWindowRect, EquipmentWindow, "Equipment");
		}
	}
	private void InventoryWindow(int windowID) {
		float buttonWidth = (inventoryWindowRect.width - (2 * sideBuffer)) / inventoryCols;
		float buttonHeight = (inventoryWindowRect.height - (topBuffer * 2)) / inventoryRows;
		for(int i = 0; i < inventoryRows; i++){
			for(int j = 0; j < inventoryCols; j++){
				if(GUI.Button(new Rect(sideBuffer + buttonWidth * j, topBuffer + (buttonHeight * i), buttonWidth, buttonHeight),
				 "" + ((i*4) + (j+1))/* character.Inventory.At(i-1).Icon */)){
					//equip the item
					character.EquipItem(character.Inventory[(i*4) + j]);
				}
			}
		}
        GUI.DragWindow();
    }
	private void EquipmentWindow(int windowID) {
		
		if(GUI.Button(headSlotRect, new GUIContent("Head", character.HeadArmor.GetToolTip()))){
			character.UnequipHead();
		}
		if(GUI.Button(torsoSlotRect, new GUIContent("Torso", character.TorsoArmor.GetToolTip()))){
			character.UnequipTorso();
		}
		if(GUI.Button(legsSlotRect, new GUIContent("Legs", character.LegsArmor.GetToolTip()))){
			character.UnequipLegs();
		}
		if(GUI.Button(leftWeaponSlotRect, new GUIContent("Left", character.LeftWeapon.GetToolTip()))){
			character.UnequipLeftWeapon();
		}

        GUI.DragWindow();
    }
}
