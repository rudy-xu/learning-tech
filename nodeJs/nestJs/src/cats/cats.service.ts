import { Injectable } from "@nestjs/common";
import { CreateCatDto } from "./dto/create-cat.dto";
import { Model } from 'mongoose';
import { InjectModel } from '@nestjs/mongoose';
import { Cat } from "./entities/cats.schema";

@Injectable()
export class CatsService {
  constructor(@InjectModel(Cat.name) private readonly catModel: Model<Cat>) {}

  async create(createCatDto: CreateCatDto): Promise<Cat> {
    const createdCat = await this.catModel.create(createCatDto);
    return createdCat;
  }
}