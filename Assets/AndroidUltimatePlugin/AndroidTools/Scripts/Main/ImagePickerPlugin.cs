﻿using System;
using Gigadrillgames.AUP.Common;
using UnityEngine;

namespace Gigadrillgames.AUP.Tools
{
    public class ImagePickerPlugin : MonoBehaviour
    {
        private static ImagePickerPlugin instance;
        private static GameObject container;
        private const string TAG = "[ImagePickerPlugin]: ";
        private static AUPHolder aupHolder;

        private Action<string> GetImageComplete;

        public event Action<string> OnGetImageComplete
        {
            add { GetImageComplete += value; }
            remove { GetImageComplete += value; }
        }

        private Action<string> GetImagesComplete;

        public event Action<string> OnGetImagesComplete
        {
            add { GetImagesComplete += value; }
            remove { GetImagesComplete += value; }
        }

        private Action GetImageCancel;

        public event Action OnGetImageCancel
        {
            add { GetImageCancel += value; }
            remove { GetImageCancel += value; }
        }

        private Action GetImageFail;

        public event Action OnGetImageFail
        {
            add { GetImageFail += value; }
            remove { GetImageFail += value; }
        }

        private Action<string> GetImageCropComplete;

        public event Action<string> OnGetImageCropComplete
        {
            add { GetImageCropComplete += value; }
            remove { GetImageCropComplete += value; }
        }

        private Action GetImageCropFail;

        public event Action OnGetImageCropFail
        {
            add { GetImageCropFail += value; }
            remove { GetImageCropFail += value; }
        }

#if UNITY_ANDROID
        private static AndroidJavaObject jo;
#endif

        public bool isDebug = true;
        private bool isInit = false;

        public static ImagePickerPlugin GetInstance()
        {
            if (instance == null)
            {
                container = new GameObject();
                container.name = "ImagePickerPlugin";
                instance = container.AddComponent(typeof(ImagePickerPlugin)) as ImagePickerPlugin;
                DontDestroyOnLoad(instance.gameObject);
                aupHolder = AUPHolder.GetInstance();
                instance.gameObject.transform.SetParent(aupHolder.gameObject.transform);
            }

            return instance;
        }

        private void Awake()
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                jo = new AndroidJavaObject("com.gigadrillgames.androidplugin.image.ImagePlugin");
            }
#endif
        }

        /// <summary>
        /// Sets the debug.
        /// 0 - false, 1 - true
        /// </summary>
        /// <param name="debug">Debug.</param>
        public void SetDebug(int debug)
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                jo.CallStatic("SetDebug", debug);
                Utils.Message(TAG, "SetDebug");
            }
            else
            {
                Utils.Message(TAG, "warning: must run in actual android device");
            }
#endif
        }

        /// <summary>
        /// initialize the Image Picker Plugin
        /// </summary>
        public void Init()
        {
            if (isInit)
            {
                return;
            }

#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                jo.CallStatic("init");
                isInit = true;
                SetImagePickerCallbackListener(onGetImageComplete, onGetImagesComplete, onGetImageCancel,
                    onGetImageFail, onGetImageCropComplete, onGetImageCropFail);
                Utils.Message(TAG, "init");
            }
            else
            {
                Utils.Message(TAG, "warning: must run in actual android device");
            }
#endif
        }

        /// <summary>
        /// Sets the image picker callback listener.
        /// </summary>
        /// <param name="onGetImageComplete">On get image complete.</param>
        /// <param name="onGetImagesComplete">On get images complete.</param>
        /// <param name="onGetImageCancel">On get image cancel.</param>
        /// <param name="onGetImageFail">On get image fail.</param>
        private void SetImagePickerCallbackListener(Action<string> onGetImageComplete,
            Action<string> onGetImagesComplete, Action onGetImageCancel, Action onGetImageFail,
            Action<string> onGetImageCropComplete, Action onGetImageCropFail)
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                ImagePickerCallback imagePickerCallback = new ImagePickerCallback();
                imagePickerCallback.onGetImageComplete = onGetImageComplete;
                imagePickerCallback.onGetImagesComplete = onGetImagesComplete;
                imagePickerCallback.onGetImageCancel = onGetImageCancel;
                imagePickerCallback.onGetImageFail = onGetImageFail;
                imagePickerCallback.onGetImageCropComplete = onGetImageCropComplete;
                imagePickerCallback.onGetImageCropFail = onGetImageCropFail;

                jo.CallStatic("setImagePickerCallbackListener", imagePickerCallback);
                Utils.Message(TAG, "setCameraCallbackListener");
            }
            else
            {
                Utils.Message(TAG, "warning: must run in actual android device");
            }
#endif
        }

        /// <summary>
        /// Gets the image.
        /// start activity to pick one image only
        /// </summary>
        public void GetImage()
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                jo.CallStatic("getImage");
                Utils.Message(TAG, "getImage");
            }
            else
            {
                Utils.Message(TAG, "warning: must run in actual android device");
            }
#endif
        }

        /// <summary>
        /// opens up a custom gallery activity for you to select 2 or more images
        /// note: the order of images loaded is depends on how they are organized on your phone
        /// directory and it's not based on the order you select them
        /// </summary>
        public void GetImages()
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                jo.CallStatic("getImages");
                Utils.Message(TAG, "getImages");
            }
            else
            {
                Utils.Message(TAG, "warning: must run in actual android device");
            }
#endif
        }

        /// <summary>
        /// dispatch when image successfully get.
        /// </summary>
        /// <param name="imagePath">Image path.</param>
        private void onGetImageComplete(string imagePath)
        {
            if (null != GetImageComplete)
            {
                GetImageComplete(imagePath);
            }
        }

        /// <summary>
        /// dispatch when images successfully get.
        /// </summary>
        /// <param name="imagePath">Image path.</param>
        private void onGetImagesComplete(string imagePath)
        {
            if (null != GetImagesComplete)
            {
                GetImagesComplete(imagePath);
            }
        }

        /// <summary>
        /// dispatch when user didn't select anything
        /// </summary>
        private void onGetImageCancel()
        {
            if (null != GetImageCancel)
            {
                GetImageCancel();
            }
        }

        /// <summary>
        /// dispatch when fail getting image
        /// </summary>
        private void onGetImageFail()
        {
            if (null != GetImageFail)
            {
                GetImageFail();
            }
        }

        /// <summary>
        /// Gets the image.
        /// start activity to pick one image only
        /// </summary>
        public void GetImageCrop(string cropImageDestinationPath, int width, int height)
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                jo.CallStatic("getImageCrop", cropImageDestinationPath, width, height);
                Utils.Message(TAG, "getImageCrop");
            }
            else
            {
                Utils.Message(TAG, "warning: must run in actual android device");
            }
#endif
        }

        /// <summary>
        /// dispatch when image successfully get crop image.
        /// </summary>
        /// <param name="imagePath">Image path.</param>
        private void onGetImageCropComplete(string imagePath)
        {
            if (null != GetImageCropComplete)
            {
                GetImageCropComplete(imagePath);
            }
        }

        /// <summary>
        /// dispatch when fail getting image crop
        /// </summary>
        private void onGetImageCropFail()
        {
            if (null != GetImageCropFail)
            {
                GetImageCropFail();
            }
        }
    }
}