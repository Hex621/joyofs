using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Assets.Scripts
{
    public class Cock : MonoBehaviour
    {
        //private IAreaEffectorModifier CurrentAreaEffectorStrategy = new AreaEffectorModifierWithForceMagnitudeandForceVariation();
        private ICapsuleColliderMaker CurrentCapsuleColliderMaker = new CapsuleColliderMakerwithNoGap();
        private IChangeWheelJointProperties CurrentChangeWheelJointProperties = new WheelJointPropertyChangerBasedOnSlider();
        private IMakeAreaEffector CurrentMakeAreaEffector = new MakeAreaEffectorWithBurntInLayer();
        private IPolyColliderMaker CurrentPolyColliderMaker = new StaticPolygonColliderMakerUsingBonePositions();
        private IRigidbodyMaker CurrentRigidbodyMaker = new RigidbodyMakerWithBurntInValues();
        private ISpringMaker CurrentSpringMaker = new SpringMakerBetweenBones();
        private ISpringModifier CurrentSpringModifier = new SpringStiffnessModifierWithFrequencyandDamping();
        private ITempBoneMaker CurrentTempBoneMaker = new MakeTempBoneForWheelJoints();
        private IWheelJointMaker CurrentWheelJointMaker = new MakeWheelJointsattheBonesPositionsAndBasedOnSectionNumber();
        private IWheelJointSuspensionModifier CurrentWheelJointSuspensionModifier = new WheelJointSuspensionDampingandFrequencyModifier();



        private List<Vector2> points = new List<Vector2>();
        private List<Component> boneList = new List<Component>();
        private List<List<Component>> sections = new List<List<Component>>();

        [SerializeField] public float Damping { get; set; } = 0.8f;
        [SerializeField] public float Frequency { get; set; } = 8f;
        // Start is called before the first frame update
        void Start()
        {
            

            List<int> sectionnumbers = new List<int>();
            foreach (Transform child in transform)
            {
                //Debug.Log(child.gameObject.name);
            }

            int section = 0;

            int counter = 0;
            Component[] bones2 = GetComponentsInChildren<Transform>();
            List<Component> bones = bones2.ToList();
            bones.RemoveAt(0);
            bool afterChild = false;
            sections.Add(new List<Component>());

            foreach (Component bone in bones)
            {
                boneList.Add(bone);
                //Debug.Log(bone.gameObject.name);
                if (bone.gameObject.name != "TestCock4x-better")
                {
                    //Instantiate(bone.gameObject);
                    //GameObject tempBone = TempBoneMaker(bones, bone);
                    GameObject tempBone = CurrentTempBoneMaker.TempBoneMakerStrategy(bones, bone);
                    tempBone.transform.parent = null;
                    sections[section].Add(bone);

                    if (section < 2) //Make variable
                    {
                        points.Add(new Vector2(bone.gameObject.transform.position.x, bone.gameObject.transform.position.y));
                        //Debug.Log(bone.gameObject.transform.name + " " +section);
                        if (counter != 0 && !afterChild)
                        {
                            //SpringMaker(counter, bones, bone, Damping, Frequency);
                            CurrentSpringMaker.SpringMakerStrategy(counter, bones, bone, Damping, Frequency);

                        }

                        afterChild = false;

                    }
                    if (bone.transform.childCount == 0)
                    {
                        sections.Add(new List<Component>());
                        section++;
                        sectionnumbers.Add(counter);
                        afterChild = true;
                    }
                    CurrentRigidbodyMaker.RigidbodyMakerStrategy(bone);
                    //RigidbodyManager(bone);

                    //CapsuleColliderManager(section, bone);
                    if (bone.transform.childCount != 0)
                    {
                        CurrentCapsuleColliderMaker.CapsuleColliderMakerStrategy(section, counter, bones, bone);
                        //CapsuleColliderMaker(section, counter, bones, bone);
                    }
                    CurrentWheelJointMaker.WheelJointManager(section, bone, tempBone);
                    //WhellJointManager(section, bone, tempBone);
                    counter++;

                }
            }
            //points.Reverse(0, sectionnumbers[0]+1);
            CurrentPolyColliderMaker.PolyColliderMakerStrategy(sectionnumbers, points, this.gameObject);
            //PolyColliderMaker(sectionnumbers);
            CurrentMakeAreaEffector.MakeAreaEffectorStrategy(this.gameObject);
            //MakeAreaEffector();

        }
        
        private static void CapsuleColliderMaker(int section, int counter, List<Component> bones, Component bone)
        {
            float distance = Vector2.Distance(bones[counter + 1].transform.position, bone.transform.position);
            //Debug.Log(distance);
            CapsuleCollider2D temp2 = bone.gameObject.AddComponent(typeof(CapsuleCollider2D)) as CapsuleCollider2D;
            bone.gameObject.GetComponent<CapsuleCollider2D>().direction = CapsuleDirection2D.Horizontal;
            bone.gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(distance, distance * 0.8f);
            if (section == 0)
            {
                bone.gameObject.GetComponent<CapsuleCollider2D>().offset = new Vector2(distance / 2, 0.025f);
            }
            else if (section == 1)
            {
                bone.gameObject.GetComponent<CapsuleCollider2D>().offset = new Vector2(distance / 2, -0.023f);
            }
        }
        
        /*
        private static void SpringMaker(int counter, List<Component> bones, Component bone, float frequency, float damping)
        {
            SpringJoint2D spring1 = bone.gameObject.AddComponent(typeof(SpringJoint2D)) as SpringJoint2D;
            SpringModifier(spring1, frequency, damping);
            spring1.connectedBody = bones[counter - 1].GetComponent<Rigidbody2D>();
        }
        */

        private static void SpringModifier(SpringJoint2D spring1, float frequency, float damping)
        {
            spring1.frequency = 8f;
            spring1.dampingRatio = 0.8f;
        }

        private void MakeAreaEffector()
        {
            AreaEffector2D temp1 = gameObject.AddComponent(typeof(AreaEffector2D)) as AreaEffector2D;
            gameObject.GetComponent<AreaEffector2D>().useColliderMask = true;
            gameObject.GetComponent<AreaEffector2D>().forceMagnitude = 0;
            gameObject.GetComponent<AreaEffector2D>().forceVariation = 0;
            int layer = 8;
            gameObject.GetComponent<AreaEffector2D>().colliderMask = 1 << layer;
        }

        private static GameObject TempBoneMaker(List<Component> bones, Component bone)
        {
            var tempBone = Instantiate(bone.gameObject, new Vector3(bone.gameObject.transform.position.x, bone.gameObject.transform.position.y, bone.gameObject.transform.position.z), bone.transform.rotation);
            if (tempBone.transform.childCount > 0) { Destroy(tempBone.transform.GetChild(0).gameObject); }
            tempBone.transform.SetParent(bones[0].transform);

            Rigidbody2D temp0 = tempBone.gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            tempBone.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            return tempBone;
        }

        private void PolyColliderMaker(List<int> sectionnumbers)
        {
            points.Reverse((sectionnumbers[0]) + 1, sectionnumbers[1] - sectionnumbers[0]);
            PolygonCollider2D temp1 = gameObject.AddComponent(typeof(PolygonCollider2D)) as PolygonCollider2D;
            points.RemoveAt(points.Count - 1); //Should try to figure why is this scuffed
                                               //points.Add(points[0]);
            gameObject.GetComponent<PolygonCollider2D>().points = points.ToArray();
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            gameObject.GetComponent<PolygonCollider2D>().usedByEffector = true;

        }

        private static void WhellJointManager(int section, Component bone, GameObject tempBone)
        {
            WheelJoint2D temp3 = bone.gameObject.AddComponent(typeof(WheelJoint2D)) as WheelJoint2D;
            JointSuspension2D suspension = temp3.suspension;
            if (section == 0) //make it into a array or something
            {
                suspension.frequency = 3f;
                suspension.dampingRatio = 0.8f;
            }
            else if (section == 1)
            {
                suspension.frequency = 1f;
                suspension.dampingRatio = 0.5f;
            }
            temp3.suspension = suspension;
            bone.gameObject.GetComponent<WheelJoint2D>().connectedBody = tempBone.GetComponent<Rigidbody2D>();
        }

        private static void RigidbodyManager(Component bone)
        {
            Rigidbody2D temp1 = bone.gameObject.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            bone.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            bone.gameObject.GetComponent<Rigidbody2D>().drag = 0.5f;
            bone.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        }


        public void ChangeWheelJointProperties(GameObject slider)
        {
            if (slider.gameObject.name.Equals("CockTopSlider"))
            {
                foreach (Component bone in sections[0])
                {
                    WheelJointSuspensionModifier(slider, bone);

                }
            }
            else
            {
                foreach (Component bone in sections[1])
                {
                    WheelJointSuspensionModifier(slider, bone);

                }
            }
        }

        private static void WheelJointSuspensionModifier(GameObject slider, Component bone)
        {
            JointSuspension2D suspension = bone.gameObject.GetComponent<WheelJoint2D>().suspension;
            suspension.frequency = 3f * slider.GetComponent<UnityEngine.UI.Slider>().value;
            suspension.dampingRatio = 0.8f * slider.GetComponent<UnityEngine.UI.Slider>().value;
            bone.gameObject.GetComponent<WheelJoint2D>().suspension = suspension;
        }

        public void AreaEffectorChanger(GameObject slider)
        {
            gameObject.GetComponent<AreaEffector2D>().forceMagnitude = -300 * slider.GetComponent<UnityEngine.UI.Slider>().value;
            gameObject.GetComponent<AreaEffector2D>().forceVariation = 200 * slider.GetComponent<UnityEngine.UI.Slider>().value;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
