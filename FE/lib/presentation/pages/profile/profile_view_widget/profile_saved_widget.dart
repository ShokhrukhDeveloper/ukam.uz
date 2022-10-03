import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:referat/app_colors/app_colors.dart';
import 'package:referat/app_colors/app_text_styles.dart';

class ProfileSavedWidget {
  static profileSavedWidget(BuildContext context) {
    return SizedBox(
      height: MediaQuery.of(context).size.height * 0.65,
      width: MediaQuery.of(context).size.width * 0.65,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Text(
            'Сақланганлар',
            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 30),
          ),
          SizedBox(
            width: MediaQuery.of(context).size.width,
            height: 300,
            child: ListView.builder(
              itemCount: 3,
              scrollDirection: Axis.horizontal,
              itemBuilder: (context, index) => SizedBox(
                child: Container(
                  width: 350,
                  height: 300,
                  child: Row(
                    children: [
                      //?Book Image
                      Container(
                        width: 140,
                        height: 195,
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(14),
                          image: const DecorationImage(
                            image: NetworkImage(
                                'https://source.unsplash.com/random'),
                            fit: BoxFit.cover,
                          ),
                        ),
                      ),
                      const SizedBox(width: 10),
                      //? Text About Book
                      SizedBox(
                        height: 196,
                        width: 195,
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              mainAxisAlignment: MainAxisAlignment.start,
                              children: [
                                //? BookName text, Rating, Rating type, Book text,
                                const Text(
                                  "Элжернга аталган гуллар",
                                  style: AppTextStyles.text24W500Black,
                                  maxLines: 2,
                                  overflow: TextOverflow.ellipsis,
                                ),
                                const SizedBox(height: 10),
                                //? Rating, Rating type
                                Row(
                                  mainAxisSize: MainAxisSize.min,
                                  children: const [
                                    Icon(Icons.star,
                                        size: 20, color: Color(0xffFF754C)),
                                    SizedBox(width: 5),
                                    Text(
                                      "4.7",
                                      style: AppTextStyles.text28W700Style,
                                    ),
                                    SizedBox(width: 5),
                                    Text('244 фиклар',
                                        style: TextStyle(
                                            color: Colors.grey, fontSize: 14)),
                                  ],
                                ),
                                const SizedBox(height: 15),
                                //? Book Type text
                                const SizedBox(
                                  width: 165,
                                  child: Text(
                                    "SIYOSAT, FANTASTIKA ",
                                    overflow: TextOverflow.ellipsis,
                                    style: AppTextStyles.text14W400Style,
                                    maxLines: 1,
                                  ),
                                ),
                                const SizedBox(height: 15),
                              ],
                            ),
                            //? Ochiriw text
                            Row(
                              mainAxisAlignment: MainAxisAlignment.start,
                              children: const [
                                Padding(
                                  padding: EdgeInsets.only(bottom: 10),
                                  child: Text(
                                    "Ўчириш",
                                    style: AppTextStyles.text28W700Style,
                                  ),
                                ),
                              ],
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}

Widget comment() {
  return SizedBox(
    width: 15,
    height: 15,
    child: Stack(
      children: const [
        Align(
            alignment: Alignment.center,
            child: Icon(CupertinoIcons.chat_bubble_fill,
                size: 20, color: AppColors.grey)),
        Positioned(
            top: 4,
            right: 0,
            child: Text(
              "9+",
              textAlign: TextAlign.center,
              style: TextStyle(
                  color: Colors.red, fontSize: 8, fontWeight: FontWeight.bold),
            ))
      ],
    ),
  );
}
