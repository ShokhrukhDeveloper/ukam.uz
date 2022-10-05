import 'package:cached_network_image/cached_network_image.dart';
import 'package:flutter/material.dart';
import 'package:referat/app_colors/app_colors.dart';
import 'package:referat/app_colors/app_text_styles.dart';

import '../widgets/similar widget.dart';

class ProductDataWidget extends StatefulWidget {
  const ProductDataWidget({Key? key}) : super(key: key);

  @override
  State<ProductDataWidget> createState() => _ProductDataWidgetState();
}

class _ProductDataWidgetState extends State<ProductDataWidget> {
  Map<String,String> types={
    "Муаллиф":"Даниел КИЗ",
    "Китоб номи":"Элжернга аталган гуллар",
    "Тил":"Ўзбек",
    "ISBN":"121341381648 (ISBN13: 121341381648)",
    "Сахифалар":"450",
    "Чоп этилган сана":"Апрель 7, 1999",
    "Нашриёт":"Wepress Inc.",
    "Рукн":"SIYOSAT,SIYOSAT",

  };
  var fikr=false;
  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.only(left: 20,right: 20),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          SizedBox(
          width: 500,
            child: Row(
            mainAxisAlignment: MainAxisAlignment.start,
              children: [
               Row(
                 children: [
                   fikr? Column(
                      mainAxisAlignment: MainAxisAlignment.start,
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        SizedBox(
                          width: 400,
                          height: 50,
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.start,
                            children: [
                              const SizedBox(width: 8,),
                              SizedBox( width: 150,
                                child: TextButton(
                                  onPressed: (){
                                    fikr=!fikr;
                                    setState(() {});
                                  },
                                  child: const Text("Ma'lumotlar",
                                    style: AppTextStyles.text24W500Black,
                                  ),
                                ),
                              ),
                              TextButton(
                                onPressed: (){},
                                child: const Text("Fikrlar",
                                  style: AppTextStyles.text24W500Gray,
                                ),
                              ),

                            ],
                          ),
                        ),
                        ...types.entries.map((index) => Container(
                          width: 500,
                          height: 40,
                          decoration: BoxDecoration(border: Border.all(color: AppColors.grey)),
                          child: Row(
                            children: [
                              const SizedBox(width: 8,),
                              SizedBox( width: 150, child: Text("${index.key}",
                                style: AppTextStyles.text14BoldStyleBlack,
                                overflow: TextOverflow.ellipsis,
                              ),),
                              SizedBox( width: 340, child: Text("${index.value}",
                                overflow: TextOverflow.ellipsis,
                                style: AppTextStyles.text14W400StyleGrey,
                              ),),
                            ],
                          ),
                        )),
                      ],
                    ):
                    Column(
                      children: [
                        SizedBox(
                          width: 400,
                          height: 50,
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.start,
                            children: [
                              const SizedBox(width: 8,),
                              SizedBox( width: 150,
                                child: TextButton(
                                  onPressed: (){},
                                    child: const Text("Ma'lumotlar",
                                      style: AppTextStyles.text24W500Black,
                                    ),
                                ),
                              ),
                              TextButton(
                                onPressed: (){
                                  fikr=!fikr;
                                  setState(() {});
                                },
                                child: const Text("Fikrlar",
                                  style: AppTextStyles.text24W500Gray,
                                ),
                              ),

                            ],
                          ),
                        ),
                        Container(
                          padding: const EdgeInsets.all(10),
                          height: 200,
                            width: 500,
                          decoration: BoxDecoration(
                            border: Border.all(color: AppColors.grey),
                            borderRadius: BorderRadius.circular(14)
                          ),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              const SizedBox(width: 150, child: const Text("Fikringiz",style: AppTextStyles.text18W400Black)),
                              const SizedBox(height: 10,),
                              Container(

                                decoration: BoxDecoration(
                                  borderRadius: BorderRadius.circular(15),
                                  color: AppColors.grey,
                                ),
                                child: TextField(

                                  maxLines: 3,
                                  decoration: InputDecoration(
                                    border: OutlineInputBorder(
                                      borderRadius: BorderRadius.circular(15),
                                      borderSide: const BorderSide(color: AppColors.grey)
                                    )
                                  ),
                                ),
                              ),
                              const SizedBox(height: 10,),
                              FloatingActionButton.extended(onPressed: (){}, label: const Text("Yuborish"))
                            ],
                          ),

                        ),
                        Container(
                          margin: const EdgeInsets.only(top: 10),
                          padding: const EdgeInsets.all(10),

                            width: 500,
                          decoration: BoxDecoration(
                            border: Border.all(color: AppColors.grey),
                            borderRadius: BorderRadius.circular(14)
                          ),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                             ListTile(

                               leading: Container(
                                   width: 50,
                                   height: 50,
                                 decoration: BoxDecoration(
                                   borderRadius: BorderRadius.circular(14),
                                   image: const DecorationImage(
                                     image: const CachedNetworkImageProvider("https://picsum.photos/200/300",
                                     // cacheManager:
                                     ),
                                     fit: BoxFit.cover
                                   )
                                 ),

                               ),
                               title: const Text("Abdullayev Asadbek"),
                               subtitle: const Text("Апрель 7, 2020"),
                             ),
                              const SizedBox(height: 15,),

                              const Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Commodo ipsum aenean sem sed arcu faucibus et. Id scelerisque enim vitae vitae pellentesque.")
                            ],
                          ),

                        ),
                        Container(
                          margin: const EdgeInsets.only(top: 10),
                          padding: const EdgeInsets.all(10),

                            width: 500,
                          decoration: BoxDecoration(
                            border: Border.all(color: AppColors.grey),
                            borderRadius: BorderRadius.circular(14)
                          ),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                             ListTile(

                               leading: Container(
                                   width: 50,
                                   height: 50,
                                 decoration: BoxDecoration(
                                   borderRadius: BorderRadius.circular(14),
                                   image: const DecorationImage(
                                     image:  CachedNetworkImageProvider("https://picsum.photos/200/300"),
                                     fit: BoxFit.cover
                                   )
                                 )
                               ),
                               title: const Text("Abdullayev Asadbek"),
                               subtitle: const Text("Апрель 7, 2020"),
                             ),
                              const SizedBox(height: 15,),

                              const Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Commodo ipsum aenean sem sed arcu faucibus et. Id scelerisque enim vitae vitae pellentesque.")
                            ],
                          ),

                        ),
                        Container(
                          margin: const EdgeInsets.only(top: 10),
                          padding: const EdgeInsets.all(10),

                            width: 500,
                          decoration: BoxDecoration(
                            border: Border.all(color: AppColors.grey),
                            borderRadius: BorderRadius.circular(14)
                          ),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                             ListTile(

                               leading: Container(
                                   width: 50,
                                   height: 50,
                                 decoration: BoxDecoration(
                                   borderRadius: BorderRadius.circular(14),
                                   image: const DecorationImage(
                                     image: CachedNetworkImageProvider("https://picsum.photos/200/300"),
                                     fit: BoxFit.cover
                                   )
                                 ),

                               ),
                               title: const Text("Abdullayev Asadbek"),
                               subtitle: const Text("Апрель 7, 2020"),
                             ),
                              const SizedBox(height: 15,),

                              const Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Commodo ipsum aenean sem sed arcu faucibus et. Id scelerisque enim vitae vitae pellentesque.")
                            ],
                          ),

                        ),
                        Container(
                          margin: const EdgeInsets.only(top: 10),
                          padding: const EdgeInsets.all(10),

                            width: 500,
                          decoration: BoxDecoration(
                            border: Border.all(color: AppColors.grey),
                            borderRadius: BorderRadius.circular(14)
                          ),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                             ListTile(

                               leading: Container(
                                   width: 50,
                                   height: 50,
                                 decoration: BoxDecoration(
                                   borderRadius: BorderRadius.circular(14),
                                   image: const DecorationImage(
                                     image: CachedNetworkImageProvider("https://picsum.photos/200/300"),
                                     fit: BoxFit.cover
                                   )
                                 ),

                               ),
                               title: const Text("Abdullayev Asadbek"),
                               subtitle: const Text("Апрель 7, 2020"),
                             ),
                              const SizedBox(height: 15,),

                              const Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Commodo ipsum aenean sem sed arcu faucibus et. Id scelerisque enim vitae vitae pellentesque.")
                            ],
                          ),

                        ),
                        const SizedBox(height: 15,),
                        FloatingActionButton.extended(onPressed: (){}, label: const Text("Ko'proq")),
                        const SizedBox(height: 30,),
                      ],
                    ),



                 ],
               )],
            ),
          ),
          SizedBox(
            width: 330,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.start,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                const Padding(
                  padding: const EdgeInsets.all(14),
                  child: const Text("O'xshashlar",
                    style: AppTextStyles.text24W500Black,
                  ),
                ),
                const SimilarWidget(),
                const SizedBox(height: 15,),
                const SimilarWidget(),
                const SizedBox(height: 15,),
                const SimilarWidget(),
                const SizedBox(height: 15,),
                FloatingActionButton.extended(onPressed: (){}, label: const Text("Ko'proq"))

              ],
            ),
          )
        ],
      ),
    );
  }
}
