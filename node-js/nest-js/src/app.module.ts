import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { TestModule } from './test/test.module';
import { ConfigModule } from '@nestjs/config';
import config from './configuration/config.js';
@Module({
  imports: [
    TestModule,
    ConfigModule.forRoot({
      isGlobal: true,
      load: [config]
    })
  ],
  controllers: [AppController],
  providers: [AppService],
})
export class AppModule {}
